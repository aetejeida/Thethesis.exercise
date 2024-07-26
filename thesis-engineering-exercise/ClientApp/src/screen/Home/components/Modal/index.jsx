import React, { useState } from "react";
import PropTypes from "prop-types";
import { Modal, ModalHeader,ModalBody,Button, ModalFooter } from "reactstrap";

const ModalDialog = ({ isOpen, title, content, buttonText, cancel, handleOnChange, showButtons, additionalClassName, doActionOnClose, onClosed }) => {
    const [modalOpen, setModalOpen] = useState(isOpen)
    const toggle = () => {
      setModalOpen(!modalOpen)
      if (doActionOnClose) {
        handleOnChange()
      }
    }
  
    const onClick = () => {
      toggle()
      handleOnChange()
    }
  
    return (
      <div className='modal-dialog'>
        <Modal
          centered
          fullscreen='sm'
          size='md'
          isOpen={modalOpen}
          toggle={toggle}
          onClosed={onClosed}
          className={additionalClassName}
        >
          <ModalHeader toggle={toggle} close={<button type='button' className='btn btn-danger' onClick={toggle}>Close</button>}>{title}</ModalHeader>
          <ModalBody>{content}</ModalBody>
          {showButtons && (
          <ModalFooter>
            <Button color='none' className='btn btn-primary' onClick={toggle}>{cancel}</Button>{' '}
            <Button color='none' className='btn btn-success' onClick={onClick}>
              {buttonText}
            </Button>
          </ModalFooter>)}
        </Modal>
      </div>
    )
  }
  
  ModalDialog.propTypes = {
    isOpen: PropTypes.bool,
    showButtons: PropTypes.bool,
    title: PropTypes.string,
    content: PropTypes.element,
    buttonText: PropTypes.string,
    cancel: PropTypes.string,
    handleOnChange: PropTypes.func,
    additionalClassName: PropTypes.string,
    doActionOnClose: PropTypes.bool,
    onClosed: PropTypes.func
  }

export default ModalDialog;
