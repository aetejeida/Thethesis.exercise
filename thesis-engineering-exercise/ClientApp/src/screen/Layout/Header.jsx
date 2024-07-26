import React from "react";
import PropTypes from "prop-types";

const Header = ({ search, handlerCreateFormModal, handlerInputSerch}) => {
    return (
    <>
      <h1 id="tableLabel">Computer Catalog</h1>
      <div className="row">
        <div className="col">
          <button
            type="button"
            className="btn btn-primary"
            onClick={handlerCreateFormModal}
          >
            Add Computer
          </button>
        </div>
        <div className="col">
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Search here..."
              value={search}
              onChange={handlerInputSerch}
            />
          </div>
        </div>
      </div>

      <div>Fill out the table below based on your database design</div>
    </>
  );
};

Header.propTypes = {
    search: PropTypes.string,
    handlerCreateFormModal: PropTypes.func,
    handlerInputSerch: PropTypes.func
}

export default Header;