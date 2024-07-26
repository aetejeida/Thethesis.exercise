import React from "react";
import PropTypes from "prop-types";

function Select({ options, handlerOnChange, handlerOnClick, className, value, name, defaultValue }) {
  const handlerSelectOnChange = (event) => {
    if (handlerOnChange) {
      handlerOnChange(event);
    }
  };

  const handlerSelectOnClick = (event) => {
    if (handlerOnClick) {
      handlerOnClick(event);
    }
  };
  return (
    <select
      onChange={handlerSelectOnChange}
      className={className}
      value={value}
      name={name}
      onClick={handlerSelectOnClick}
      defaultValue={defaultValue}
    >
      {options &&
        options.map((option, index) => {
          const selectKey = `option-${index}`;
          return (<option key={selectKey} value={option.id}>{option.name}</option>);
        })}
    </select>
  );
}

Select.propTypes = {
  options: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.any),
    PropTypes.shape(),
  ]),
  handlerOnChange: PropTypes.func,
  handlerOnClick: PropTypes.func,
  className: PropTypes.string,
  value: PropTypes.any,
  name: PropTypes.string,
  defaultValue: PropTypes.number
};

export default Select;
