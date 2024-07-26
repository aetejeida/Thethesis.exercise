import { cleanup } from "@testing-library/react";
import { mappingFormToRequest, parseToJson } from "./utils";

describe("Testing App Component", () => {
    afterEach(() => {
      cleanup();
    });

    it("parseToJson correctly parsing with data", () => {
        const testData = {
            name: 'Angel Tejeida',
            age: "30",
            direction: 'Gómez Palacio, Durango',
            country: 'México',
            role: 'Senior Software Developer'
        };
        const formData = new FormData();
        formData.append("name", testData.name);
        formData.append("age", testData.age);
        formData.append("direction", testData.direction);
        formData.append("country", testData.country);
        formData.append("role", testData.role);

        var result = parseToJson(formData);
        expect(testData).toEqual(JSON.parse(result));
    });

    it("parseToJson correctly parsing without data", () => {
        const testData = {};
        const formData = new FormData();

        var result = parseToJson(formData);
        expect(testData).toEqual(JSON.parse(result));
    });

    it("mappingFormToRequest correctly parsing with data", () => {
        const formData = new FormData();
        formData.append("computerId", "1");
        formData.append("hardDisk", "1");
        formData.append("memory", "1");
        formData.append("processors", "1");
        var response = mappingFormToRequest(parseToJson(formData), [1,2,3])
        const expectJson = JSON.stringify({...mappingFormToRequest(parseToJson(formData)), usbPortsIds: [1,2,3] });
        expect(JSON.stringify(response)).toEqual(expectJson);
    });
  });
  