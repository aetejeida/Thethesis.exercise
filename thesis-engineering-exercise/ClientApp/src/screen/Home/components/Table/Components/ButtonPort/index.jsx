import React from "react";
import PropTypes from "prop-types";

const ButtonPort = ({ handlerOnClick, tooltipDescription, name}) => {
    return (
      <button
        type="button"
        className="btn btn-outline-primary m-1"
        onClick={handlerOnClick}
        data-toggle="tooltip"
        data-placement="top"
        title={tooltipDescription}
      >
        {name}
      </button>
    );
  };

  ButtonPort.propTypes = {
    handlerOnClick: PropTypes.func,
    tooltipDescription: PropTypes.string,
    name: PropTypes.string
  }

  export default ButtonPort;