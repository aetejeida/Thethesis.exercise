import React, { useState } from "react";
import PropTypes from "prop-types";
import { useAppContext } from "../../../../context/appContext";
import { mappingFormToRequest, parseToJson } from "../../../../utils/utils";
import { createComputer } from "../../../../api/services/computerService";
import ButtonPort from "../Table/Components/ButtonPort";
import Select from "../../../../components/Select";

const CreateForm = ({ handlerOnChange }) => {
  const {
    store: { catalogs },
  } = useAppContext();

  const [usbPorts, setUsbPorts] = useState([]);
  const [usbPortSelected, setUsbPortSelected] = useState(1); //Default first usb port
  const [usbPortCounter, setUsbPortCounter] = useState(0);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const request = mappingFormToRequest(
      parseToJson(formData),
      usbPorts.map((x) => x.id)
    );
    await createComputer(request);
    handlerOnChange();
  };

  const handlerOnChangePortSelected = (event) => {
    setUsbPortSelected(event.target.value);
  };

  const handlerOnClickNewUsbPort = (event) => {
    event.preventDefault();
    const usbPortName = catalogs.usbPorts.find(
      (x) => x.id === +usbPortSelected
    )?.name;
    setUsbPortCounter((x) => x + 1);
    setUsbPorts((usbPorts) => [
      ...usbPorts,
      { index: usbPortCounter, id: +usbPortSelected, name: usbPortName },
    ]);
  };

  const handlerOnClickBadge = (id, name) => {
    setUsbPorts((usbPorts) => {
      return usbPorts
        .filter((up) => up.id === id && up.name === name)
        .splice(1, usbPorts.length - 1)
        .concat(usbPorts.filter((up) => up.id !== id && up.name !== name));
    });
  };

  return (
    <div className="col-12">
      <form onSubmit={handleSubmit}>
        <div className="row">
          <div className="col-12">
            <p className="h4">Select and Hard Disk</p>
          </div>
        </div>
        <div className="row mt-2 mb-1">
          <div className="col-12">
            <Select
              name={"hardDisk"}
              options={catalogs?.hardDisks}
              className={"form-select"}
            />
          </div>
        </div>
        <div className="row mt-2 mb-1">
          <div className="col-12">
            <p className="h4">Select and Memory</p>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <Select
              name={"memory"}
              options={catalogs?.memories}
              className={"form-select"}
            />
          </div>
        </div>
        <div className="row mt-2 mb-1">
          <div className="col-12">
            <p className="h4">Select and CPU</p>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <Select
              name={"processors"}
              options={catalogs?.processors}
              className={"form-select"}
            />
          </div>
        </div>
        <div className="row mt-2 mb-1">
          <div className="col-12">
            <p className="h4">Select and Usb Ports</p>
          </div>
        </div>

        <div className="row">
          <div className="col-6 mt-2 mb-2">
            <Select
              name={"usbPorts"}
              options={catalogs?.usbPorts}
              handlerOnChange={handlerOnChangePortSelected}
              className={"form-select"}
            />
          </div>
          <div className="col-6 mt-2 mb-2">
            <button
              type="button"
              className="btn btn-primary"
              onClick={(e) => handlerOnClickNewUsbPort(e)}
            >
              Add New Usb Port
            </button>
          </div>
        </div>
        <div className="row">
          <div className="col-12 mt-2 mb-1">
            {usbPorts &&
              usbPorts.map((p, index) => {
                const keyBtn = `Button-Port-${index}`;
                return (
                  <ButtonPort
                    key={keyBtn}
                    name={p.name}
                    handlerOnClick={() => handlerOnClickBadge(p.id, p.name)}
                    tooltipDescription={"Click to remove"}
                  />
                );
              })}
          </div>
        </div>
        <div className="row">
          <div className="d-grid gap-2 col-6 mx-auto">
            <input type="submit" value="Create" className="btn btn-primary" />
          </div>
        </div>
      </form>
    </div>
  );
};

CreateForm.propTypes = {
  handlerOnChange: PropTypes.func,
};

export default CreateForm;
