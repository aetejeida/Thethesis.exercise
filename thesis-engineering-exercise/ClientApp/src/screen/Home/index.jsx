import React, { useEffect, useState } from "react";
import CreateForm from "./components/Form";
import ComputerTable from "./components/Table";
import {
  getComputerList,
  updateComputer,
} from "../../api/services/computerService";
import ModalDialog from "./components/Modal";
import Header from "../Layout/Header";
import { useAppContext } from "../../context/appContext";
import ACTIONS from "../../context/appActions";

export const Home = () => {
  const { dispatch } = useAppContext();
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [search, setSearch] = useState("");

  const getComputersData = async (search = "") => {
    const results = await getComputerList(search);
  
    dispatch({
      type: ACTIONS.UPDATE_STATE,
      data: {
        ComputersCatalog: results,
      },
    });
  };

  //We can chenge to a custom hook
  useEffect(() => {
    (async () => {
      const handlerOnSearch = async (value) => {
        await getComputersData(value);
      };
      handlerOnSearch(search);
    })();
  }, [search]);

  useEffect(() => {
    (async () => {
      await getComputersData();
    })();
  }, []);

  const modelOnClick = () => {
    setShowCreateForm(false);
  };

  const handlerOnEdit = async (model) => {
    await updateComputer(model.computerId, model);
    await getComputersData();
  };

  const handlerOnComputerCreated = async () => {
    await getComputersData();
    setShowCreateForm(false);
  };

  return (
    <div>
      <Header
        search={search}
        handlerInputSerch={(event) => setSearch(event.target.value)}
        handlerCreateFormModal={() => {
          setShowCreateForm(true);
        }}
      />
      <ComputerTable handlerOnChange={handlerOnEdit} />
      {showCreateForm && (
        <ModalDialog
          title={"Create Computer"}
          isOpen={showCreateForm}
          onClosed={modelOnClick}
          content={<CreateForm handlerOnChange={handlerOnComputerCreated} />}
        />
      )}
    </div>
  );
};
