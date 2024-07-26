import axios from "axios";
import doRequest from "../apiBase";
import MockAdapter from "axios-mock-adapter";

describe("apibase http request", () => {
  it("apiBase doRequest good response", async () => {
    var mock = new MockAdapter(axios);
    const data = {
      computerId: 1,
      hardDisk: 1,
      memory: 1,
      processors: 1,
    };

    mock.onGet("/test").reply(200, data);

    await doRequest({
      url: `/test`,
      method: "GET",
    }).then((response) => {
      expect(response).toEqual(data);
    });
  });

  it("apiBase doRequest good response null data", async () => {
    var mock = new MockAdapter(axios);

    mock.onGet("/test").reply(200, null);

    await doRequest({
      url: `/test`,
      method: "GET",
    }).then((response) => {
      expect(response).toEqual(null);
    });
  });

  it("apiBase doRequest bad response ", async () => {
    var mock = new MockAdapter(axios);

    mock.onGet("/test").reply(404, null);

    await doRequest({
      url: `/test`,
      method: "GET",
    })
      .then((response) => {
        expect(response).toEqual(undefined);
      })
      .catch((err) => {
        expect(err).not.toBe("");
      });
  });
});
