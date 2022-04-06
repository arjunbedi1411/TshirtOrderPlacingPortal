import React from "react";
import DeleteIcon from "@material-ui/icons/Delete";
import { Button, Offcanvas, Modal } from "react-bootstrap";
import { useEffect, useState } from "react";
import EditIcon from "@material-ui/icons/Edit";
import DescriptionTshirt from "./DescriptionTshirt.jsx";
import AddEditTshirt from "./AddEditTshirt.jsx";

export default function CardTshirt(props) {
  const [sizeType, setSizeType] = useState("");
  const [styleType, setStyleType] = useState("");
  const [showCanvas, setShowCanvas] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [showModalEdit, setShowModalEdit] = useState(false);
  const [img, setImg] = useState();
  const handleCloseCanvas = () => setShowCanvas(false);
  const handleShowCanvas = () => setShowCanvas(true);
  const handleCloseModal = () => setShowModal(false);
  const handleShowModal = () => setShowModal(true);
  const handleCloseModalEdit = () => setShowModalEdit(false);
  const handleShowModalEdit = () => setShowModalEdit(true);
  const [isShownHoverEditDelete, setIsShownHoverEditDelete] = useState(false);


  function handleResponse(response) {
    let error = {};
    return response.text().then((text) => {
      const data = text && JSON.parse(text);

      if (!response.ok) {
        error.Code = false;
        error.Message = data;
        return error;
      }
      return data;
    });
  }


  async function fetchImage(imageName) {
    const imageUrl = await fetch(
      process.env.REACT_APP_WEBAPI_URL +"File/" + imageName
    ).then(handleResponse);
    setImg(imageUrl.imageUrl);
  }



  async function deleteTshirt(id) {
    await fetch(  process.env.REACT_APP_WEBAPI_URL +"Tshirt/" + id, {
      method: "DELETE",
    }).then(handleResponse);

    props.updateData();
  }



  async function fetchStyleType(id) {
    const style = await fetch(  process.env.REACT_APP_WEBAPI_URL +"Style/" + id).then(
      handleResponse
    );
    setStyleType(style);
  }


  async function fetchSize(id) {
    const sizeType = await fetch(  process.env.REACT_APP_WEBAPI_URL +"Size/" + id).then(
      handleResponse
    );
    setSizeType(sizeType);
    }



  useEffect(() => {
    fetchStyleType(props.tShirts.style_Id);
    fetchSize(props.tShirts.size_Id);
    fetchImage(props.tShirts.product_Image_Name);
  }, []);


  return (
    <>
      <a onClick={handleShowCanvas}>
        <div
          className="card shadow-sm"
          style={{
            borderRadius: "20px",
          }}
          onMouseEnter={() => setIsShownHoverEditDelete(true)}
          onMouseLeave={() => setIsShownHoverEditDelete(false)}
        >

          <div className="card-body">
            <div
              className="card shadow-sm border border-secondary"
              style={{
                borderRadius: "5px",
              }}
            >
              {isShownHoverEditDelete && (
                <div className="text-end m-2">
                  <button
                    type="button"
                    className="btn btn-danger "
                    onClick={handleShowModal}
                  >
                    {" "}
                    <DeleteIcon />
                  </button>
                  {"    "}

                  <button
                    type="button"
                    className="btn btn-success  "
                    onClick={handleShowModalEdit}
                  >
                    <EditIcon />
                  </button>
                </div>
              )}
              <img
                src={img}
                alt="icons"
                class="rounded mx-auto d-block"
                width="200"
                height="200"
              />
            </div>
          </div>
          <div className="card-footer text-muted align-items-center">
            <div className="row position-relative">
              <div className="col text-center"> {sizeType.size_Type} </div>
              <div className="col text-center">${props.tShirts.cost}</div>{" "}
              <div className="col text-center">
                {props.tShirts.gender === "Male" ? <>M</> : <>F</>}
              </div>
            </div>
          </div>
        </div>
      </a>
  
  
      <Offcanvas show={showCanvas} onHide={handleCloseCanvas} placement="end">
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Description of the T-Shirt Item</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
          <div className="row mt-5">
            <div className="text-end">
              <button
                type="button"
                className="btn btn-danger "
                onClick={handleShowModal}
              >
                {" "}
                <DeleteIcon />
              </button>
              {"    "}

              <button
                type="button"
                className="btn btn-success  "
                onClick={handleShowModalEdit}
              >
                <EditIcon />
              </button>
            </div>
          </div>

          <DescriptionTshirt
            tshirtData={props.tShirts}
            style={styleType}
            size={sizeType}
            avatarImage={img}
          />
        </Offcanvas.Body>
      </Offcanvas>


      <AddEditTshirt
        updateData={props.updateData}
        showModalEdit={showModalEdit}
        handleCloseModalEdit={handleCloseModalEdit}
        formType={"Edit"}
        tShirts={props.tShirts}
      />



      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Tshirt</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Please click Delete button to remove tshirt from list!
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Close
          </Button>
          <Button
            variant="btn btn-danger"
            onClick={() => handleCloseModal && deleteTshirt(props.tShirts.id)}
          >
            Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
