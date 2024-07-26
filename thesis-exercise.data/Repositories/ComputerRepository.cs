using thesis_exercise.data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using thesis_exercise.model.Models;
using System.Diagnostics;
using System;

namespace thesis_exercise.data.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly ThesisExerciseContext _context;
        public ComputerRepository(ThesisExerciseContext context)
        {
            _context = context;
        }

        public async Task<Computer> Create(Computer entity)
        {
            _context.Computers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<ComputerDetail>> Get(string query)
        {
            var data = from computer in _context.Computers
                       join processor in _context.Processors on computer.ProcessorId equals processor.Id
                       join proceesorBrand in _context.ProcessorBrands on processor.BrandId equals proceesorBrand.Id
                       join hardDisk in _context.HardDisks on computer.HardDiskId equals hardDisk.Id
                       join hSizeType in _context.SizeTypes on hardDisk.SizeTypeId equals hSizeType.Id
                       join memory in _context.Memories on computer.MemoryId equals memory.Id
                       join mSizeType in _context.SizeTypes on memory.SizeTypeId equals mSizeType.Id
                       from usbPortComputer in _context.ComputerUsbPorts.Where(x => x.ComputerId.Equals(computer.Id)).DefaultIfEmpty()
                       from usbPort in _context.UsbPorts.Where(u => u.Id == usbPortComputer.UsbPortId).DefaultIfEmpty()
                       select new { computer, memory, mSizeType, hardDisk, hSizeType, processor, proceesorBrand, usbPort };
                       

            if (!string.IsNullOrWhiteSpace(query))
            {
                data = data.Where(x => x.mSizeType.TypeCode.Contains(query) || 
                                       x.proceesorBrand.Name.Contains(query) || 
                                       x.processor.Model.Contains(query) || 
                                       x.hSizeType.TypeCode.Contains(query) ||
                                       x.hardDisk.Type.Contains(query) || 
                                       x.usbPort.Version.Contains(query));

            }

            var result = data.Select(d => new ComputerDetail
            {
                ComputerId = d.computer.Id,
                Memory = $"{d.memory.Size} {d.mSizeType.TypeCode}",
                DiskSpace = $"{d.hardDisk.Size} {d.hSizeType.TypeCode} {d.hardDisk.Type}",
                Processor = $"{d.proceesorBrand.Name} {d.processor.Model}",
                UsbPorts = !string.IsNullOrEmpty(d.usbPort.Version) ? d.usbPort.Version : string.Empty
            });
            return await result.ToListAsync();
        }

        public async Task Update(int computerId, Computer model)
        {
            model.Id = computerId;

            //We remove all the relationship and add the newones
            var computerUsbPorts = _context.ComputerUsbPorts.Where(x => x.ComputerId.Equals(model.Id));
            _context.ComputerUsbPorts.RemoveRange(computerUsbPorts);
            
            var entity = _context.Computers.Update(model);
            await _context.SaveChangesAsync();
        }

        //Get all the catalogs for the Form
        public async Task<Catologs> GetCatalogs()
        {
            return new Catologs
            {
                HardDisks = await GetHardDisksCatalog(),
                Memories = await GetMemoryCatalog(),
                Processors = await GetProcessorCatalog(),
                UsbPorts = await GetUsbPortCatalog()
            };
        }

        private async Task<IList<Catalog>> GetHardDisksCatalog()
        {
            var hardDiskCatalog = from hardDisk in _context.HardDisks.AsNoTracking()
                                  join sizeType in _context.SizeTypes.AsNoTracking() on hardDisk.SizeTypeId equals sizeType.Id
                                  select new Catalog { Id = hardDisk.Id, Name = $"{hardDisk.Size} {sizeType.TypeCode} {hardDisk.Type}" };

            return await (hardDiskCatalog).ToListAsync();
        }

        private async Task<IList<Catalog>> GetMemoryCatalog()
        {
            var memoryCatalog = from memory in _context.Memories.AsNoTracking()
                                join sizeType in _context.SizeTypes.AsNoTracking() on memory.SizeTypeId equals sizeType.Id
                                select new Catalog { Id = memory.Id, Name = $"{memory.Size} {sizeType.TypeCode}" };

            return await (memoryCatalog).ToListAsync();
        }

        private async Task<IList<Catalog>> GetProcessorCatalog()
        {
            var processorCatalog = from processor in _context.Processors.AsNoTracking()
                                   join brand in _context.ProcessorBrands.AsNoTracking() on processor.BrandId equals brand.Id
                                   select new Catalog { Id = processor.Id, Name = $"{brand.Name} {processor.Model}" };

            return await (processorCatalog).ToListAsync();
        }

        private async Task<IList<Catalog>> GetUsbPortCatalog()
        {
            var usbPortCatalog = from usbPort in _context.UsbPorts.AsNoTracking()
                                 select new Catalog { Id = usbPort.Id, Name = usbPort.Version };

            return await (usbPortCatalog).ToListAsync();
        }


    }
}
