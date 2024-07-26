import React from 'react';
import PropTypes from "prop-types";
import Select from '../../../../../../components/Select';

const Row = ({isEditRow, index, value, formName, options, defaultValue}) => {
    return (
      <td>
        {isEditRow !== index ? (
          value
        ) : (
          <Select
            name={formName}
            options={options}
            defaultValue={
              defaultValue
            }
            className={'form-select'}
          />
        )}
      </td>
    );
  };

  Row.propTypes = {
    isEditRow: PropTypes.number,
    index: PropTypes.number,
    value: PropTypes.string,
    formName: PropTypes.string,
    options: PropTypes.oneOfType([
        PropTypes.arrayOf(PropTypes.any),
        PropTypes.shape(),
      ]),
    defaultValue: PropTypes.any
  }
  export default Row;