import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useAppContext } from "../../../../context/appContext";
import Row from "./Components/Row";
import { mappingFormToRequest, parseToJson } from "../../../../utils/utils";
import ButtonPort from "./Components/ButtonPort";
import Select from "../../../../components/Select";

const ComputerTable = ({ handlerOnChange, className }) => {
  const {
    store: { catalogs, ComputersCatalog },
  } = useAppContext();

  const [portButtons, setPortButtons] = useState([]);
  const [isEditRow, setIsEditRow] = useState(null);
  const [usbPortSelected, setUsbPortSelected] = useState(1); //Default first usb port

  useEffect(() => {
    updatePortButtons();
  },[usbPortSelected,]);

  const assignDefaultValue = (options, value) => {
    return options.find((x) => x.name === value)?.id;
  };

  const handlerOnSave = async (e) => {
    e.preventDefault();
    setIsEditRow(null);
    const formData = new FormData(e.target);
    const jsonObj = mappingFormToRequest(
      parseToJson(formData),
      portButtons.map((p) => p.id)
    );
    const request = { ...jsonObj };
    handlerOnChange(request);
  };

  const handlerUsbPorts = (value) => {
    if (value) {
      const ports = value?.split(",");
      ports
        .map((value) => value.split("X"))
        .forEach((element) => {
          const repeated = parseInt(element[0]);
          const version = element[1].trimEnd().trimStart();
          for (let index = 0; index < repeated; index++) {
            const id = catalogs?.usbPorts.find((e) => e.name === version)?.id;
            setPortButtons((portButtons) => [
              ...portButtons,
              { index: index, id: id, name: version },
            ]);
          }
        });
    }
  };

  const handlerUsbPortRemove = (value) => {
    setPortButtons((portButtons) => {
      return portButtons.filter((p) => p !== value);
    });
  };

  const handlerOnChangePortSelected = (event) => {
    setUsbPortSelected(event.target.value);
  };

  const updatePortButtons= () => {
    const usbPortFind = catalogs?.usbPorts.find(x => x.id === +usbPortSelected);
    setPortButtons((portButtons) => [...portButtons, { id: usbPortFind.id, name: usbPortFind.name } ]);
  }

  return (
    <div>
      <form onSubmit={handlerOnSave}>
        <table
          className={`${className} table table-striped`}
          aria-labelledby="tableLabel"
        >
          <thead>
            <tr>
              <th>Ram</th>
              <th>Disk Space</th>
              <th>Processor</th>
              <th>Ports</th>
            </tr>
          </thead>
          <tbody>
            {ComputersCatalog &&
              ComputersCatalog.map((value, index) => {
                const rowKey = `row-${index}`;
                return (
                  <tr key={rowKey}>
                    <Row
                      isEditRow={isEditRow}
                      formName={"memory"}
                      index={index}
                      value={value?.memory}
                      options={catalogs?.memories}
                      defaultValue={assignDefaultValue(
                        catalogs?.memories,
                        value?.memory
                      )}
                    />
                    <Row
                      isEditRow={isEditRow}
                      formName={"hardDisk"}
                      index={index}
                      value={value?.diskSpace}
                      options={catalogs?.hardDisks}
                      defaultValue={assignDefaultValue(
                        catalogs?.hardDisks,
                        value?.diskSpace
                      )}
                    />
                    <Row
                      isEditRow={isEditRow}
                      formName={"processors"}
                      index={index}
                      value={value?.processor}
                      options={catalogs?.processors}
                      defaultValue={assignDefaultValue(
                        catalogs?.processors,
                        value?.processor
                      )}
                    />

                    <td>
                      {isEditRow !== index
                        ? value?.usbPorts
                        : portButtons &&
                          portButtons.map((value, index) => {
                            const keyB = `k-${index}`;
                            return (
                              <ButtonPort
                                key={keyB}
                                name={value.name}
                                handlerOnClick={() =>
                                  handlerUsbPortRemove(value)
                                }
                                tooltipDescription={"Click to remove"}
                              />
                            );
                          })}
                      {isEditRow !== index ? (
                        <></>
                      ) : (
                        <div className="col-6 m-1">
                          <Select
                            name={"usbPorts"}
                            options={catalogs?.usbPorts}
                            value={usbPortSelected}
                            handlerOnChange={handlerOnChangePortSelected}
                            className={"form-select"}
                          />
                        </div>
                      )}
                    </td>
                    {isEditRow === index && (
                      <td hidden={true}>
                        <input
                          type="hidden"
                          name="computerId"
                          id="computerId"
                          value={value?.computerId}
                        />
                      </td>
                    )}
                    <td>
                      {isEditRow !== index ? (
                        <button
                          type="button"
                          className="btn btn-link"
                          onClick={() => {
                            setPortButtons([]);
                            setIsEditRow(index);
                            handlerUsbPorts(value?.usbPorts);
                          }}
                        >
                          Edit
                        </button>
                      ) : (
                        <input
                          type="submit"
                          value="Save"
                          className="btn btn-primary"
                        />
                      )}
                    </td>
                  </tr>
                );
              })}
          </tbody>
        </table>
      </form>
    </div>
  );
};

ComputerTable.propTypes = {
  handlerOnChange: PropTypes.func,
  className: PropTypes.string,
};
export default ComputerTable;
