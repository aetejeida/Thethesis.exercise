const parseToJson = (formData) => {
    var object = {};
    formData.forEach((value, key) => object[key] = value);
    var json = JSON.stringify(object);
    return json;
}

const mappingFormToRequest = (jsonRequest, usbPorts) => {
    const { computerId, hardDisk, memory, processors } = JSON.parse(jsonRequest);
    return {
      computerId: computerId,
      hardDiskId: hardDisk,
      memoryId: memory,
      processorId: processors,
      usbPortsIds: usbPorts
    };
  };

export { parseToJson , mappingFormToRequest}