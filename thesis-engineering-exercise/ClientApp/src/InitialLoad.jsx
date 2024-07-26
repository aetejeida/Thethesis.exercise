import React, { useEffect, useState } from "react";
import App from "./App";
import { AppContextComponent } from "./context/appContext";
import axios from "axios";
import { getComputerCatalogs } from "./api/services/computerService";

const InitialLoad = () => {
  const [initialState, setinitialState] = useState(undefined);

  //Here we asign the default url from de api in axios configuration
  axios.defaults.baseURL = process.env.REACT_APP_API_URL;

  useEffect(() => {
    (async () => {
      const catalogs = await getComputerCatalogs();
      setinitialState(catalogs);
    })();
  },[]);
  
  if(!initialState) {
    return <></>;
  }
  return (
    <AppContextComponent data={initialState}>
      <App />
    </AppContextComponent>
  );
};

export default InitialLoad;
