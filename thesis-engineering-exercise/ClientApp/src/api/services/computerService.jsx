import doRequest from "../apiBase";

const getComputerCatalogs = async () => {
  const response = await doRequest({
    url: "/api/computer/catalogs",
    method: "GET",
  }).catch((error) => {
    console.error("Error trying to get Computer Catalogs", error);
  });
  return response;
};

const getComputerList = async (search = '') => {
  const response = await doRequest({
    url: "/api/computer",
    method: "GET",
    params: {
      query: search,
    },
  }).catch((error) => {
    console.error("Error trying to get Computer List", error);
  });
  return response;
};

const createComputer = async (data) => {
    const response = await doRequest({
        url: "/api/computer",
        method: "POST",
        data,
      }).catch((error) => {
        console.error("Error trying to Create Computer", error);
      });
      return response;
}

const updateComputer = async (computerId, data) => {
  const response = await doRequest({
      url: `/api/computer/${computerId}`,
      method: "PATCH",
      data,
    }).catch((error) => {
      console.error("Error trying to Create Computer", error);
    });
    return response;
}

export { getComputerCatalogs, getComputerList, createComputer, updateComputer};
