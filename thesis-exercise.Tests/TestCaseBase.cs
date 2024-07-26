using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using thesis_exercise.common.LoggerManager;
using thesis_exercise.data;
using thesis_exercise.services.Mapping.Profiles;

namespace thesis_exercise.Tests
{
    internal class TestCaseBase
    {
        protected ThesisExerciseContext _dbContext { get; private set; }
        protected ILoggerManager _loggerManager { get; private set; }
        protected IMapper _mapper;

        [SetUp]
        public virtual void Setup()
        {
            _loggerManager = LoggerManager.GetInstance();

            //We setup the automapper
            var config = new MapperConfiguration(x => x.AddProfile<ComputerProfile>());
            _mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<ThesisExerciseContext>()
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInMemoryDatabase(databaseName: "FakeDataBase")
                .Options;

            _dbContext = new ThesisExerciseContext(options);
            SetupDatabase();
        }

        [TearDown]
        public virtual void TearDown() 
        {

        }

        private void SetupDatabase()
        {
            _dbContext.UsbPorts.AddRange(
                new UsbPort
                {
                    Id = 1,
                    Version = "USB 3.0",
                    CreationDate = DateTime.UtcNow,
                },
                new UsbPort
                {
                    Id = 2,
                    Version = "USB 2.0",
                    CreationDate = DateTime.UtcNow,
                },
                new UsbPort
                {
                    Id = 3,
                    Version = "USB C",
                    CreationDate = DateTime.UtcNow,
                });

            _dbContext.SizeTypes.AddRange(new SizeType
            {
                Id = 1,
                TypeCode = "TB",
                TypeName = "Terabyte",
                CreationDate = DateTime.UtcNow,
            },
            new SizeType
            {
                Id = 2,
                TypeCode = "GB",
                TypeName = "Gigabytes",
                CreationDate = DateTime.UtcNow,
            },
            new SizeType
            {
                Id = 3,
                TypeCode = "MB",
                TypeName = "Megabytes",
                CreationDate = DateTime.UtcNow,
            });

            _dbContext.ProcessorBrands.AddRange(new ProcessorBrand
            {
                Id = 1,
                Name = "Intel®"
            },
            new ProcessorBrand
            {
                Id = 2,
                Name = "AMD"
            },
            new ProcessorBrand
            {
                Id = 3,
                Name = "Intel"
            });

            _dbContext.Memories.AddRange(new Memory
            {
                Id = 1,
                Size = 8,
                SizeTypeId = 2
            },
            new Memory
            {
                Id = 2,
                Size = 16,
                SizeTypeId = 2
            },
            new Memory
            {
                Id = 3,
                Size = 32,
                SizeTypeId = 2
            },
            new Memory
            {
                Id = 4,
                Size = 512,
                SizeTypeId = 3
            },
            new Memory
            {
                Id = 5,
                Size = 2,
                SizeTypeId = 2
            });

            _dbContext.HardDisks.AddRange(new HardDisk
            {
                Id = 1,
                Type = "SSD",
                Size = "1",
                SizeTypeId = 1,
            },
            new HardDisk
            {
                Id = 2,
                Type = "HDD",
                Size = "2",
                SizeTypeId = 1,
            },
            new HardDisk
            {
                Id = 3,
                Type = "HDD",
                Size = "3",
                SizeTypeId = 1,
            },
            new HardDisk
            {
                Id = 4,
                Type = "HDD",
                Size = "4",
                SizeTypeId = 1,
            },
            new HardDisk
            {
                Id = 5,
                Type = "SSD",
                Size = "750",
                SizeTypeId = 2,
            },
            new HardDisk
            {
                Id = 6,
                Type = "SSD",
                Size = "2",
                SizeTypeId = 1,
            },
            new HardDisk
            {
                Id = 7,
                Type = "SSD",
                Size = "500",
                SizeTypeId = 2,
            },
            new HardDisk
            {
                Id = 8,
                Type = "SSD",
                Size = "80",
                SizeTypeId = 2,
            });

            _dbContext.Processors.AddRange(new Processor
            {
                Id = 1,
                BrandId = 1,
                Model = "Celeron™ N3050 Processor",
            }, new Processor
            {
                Id = 2,
                BrandId = 2,
                Model = "FX 4300 Processor",
            }, new Processor
            {
                Id = 3,
                BrandId = 2,
                Model = "Athlon Quad-Core APU Athlon 5150",
            }, new Processor
            {
                Id = 4,
                BrandId = 2,
                Model = "FX 8-Core Black Edition FX-8350",
            }, new Processor
            {
                Id = 5,
                BrandId = 2,
                Model = "FX 8-Core Black Edition FX-8370",
            }, new Processor
            {
                Id = 6,
                BrandId = 3,
                Model = "Core i7-6700K 4GHz Processor",
            }, new Processor
            {
                Id = 7,
                BrandId = 1,
                Model = "Core™ i5-6400 Processor",
            }, new Processor
            {
                Id = 8,
                BrandId = 3,
                Model = "Core i7 Extreme Edition 3 GHz Processor",
            });

            _dbContext.SaveChanges();
        }
    }
}
