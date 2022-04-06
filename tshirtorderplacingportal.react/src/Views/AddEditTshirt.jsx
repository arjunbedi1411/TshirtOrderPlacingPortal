import React from "react";
import Form from "react-bootstrap/Form";
import { useEffect, useState } from "react";
import { Button, Modal, Col, Row } from "react-bootstrap";

export default function AddEditTshirt(props) {
  const [price, setPrice] = useState("");
  const [color, setColor] = useState("");
  const [made, setMade] = useState("");
  const [gender, setGender] = useState("");
  const [description, setDescription] = useState("");
  const [size, setSize] = useState("");
  const [style, setStyle] = useState("");
  const [sizeList, setSizeList] = useState([]);
  const [styleList, setStyleList] = useState([]);
  const [file, setFile] = useState();
  const [femaleCheckbox, setFemaleCheckbox] = useState(false);
  const [maleCheckbox, setMaleCheckbox] = useState(false);
  const [validated, setValidated] = useState(false);
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

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    } else {
      if (props.formType == "Edit") {
        handleUpdate();
      } else {
        handleSubmitAdd();
        
      }

      props.handleCloseModalEdit();
    }

    setValidated(true);
  };

  async function fileUpload() {
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("fileName", file.name);
    try {
      await fetch(  process.env.REACT_APP_WEBAPI_URL +"File", {
        method: "post",
        body: formData,
      });
    } catch (ex) {
      console.log(ex);
    }
  }

  async function fetchAllSize() {
    const sizes = await fetch(  process.env.REACT_APP_WEBAPI_URL +"Size").then(
      handleResponse
    );
    setSizeList(sizes);
  }

  async function fetchAllStyle() {
    const styles = await fetch(  process.env.REACT_APP_WEBAPI_URL +"Style").then(
      handleResponse
    );
    setStyleList(styles);
  }

function clearFormData()
{
  setAllDataEmpty();
  setValidated(false);
}

  function setFormData() {
    if (props.formType === "Edit") {
      setPrice(props.tShirts.cost);
      setColor(props.tShirts.colour);
      setMade(props.tShirts.manufature_Region);
      setGender(props.tShirts.gender);
      setDescription(props.tShirts.description);
      setSize(props.tShirts.size_Id);
      setStyle(props.tShirts.style_Id);

      if (props.tShirts.gender == "Female") {
        setFemaleCheckbox(true);
      } else {
        setMaleCheckbox(true);
      }
    }
  }

  async function handleUpdate() {
    await fetch(  process.env.REACT_APP_WEBAPI_URL +"Tshirt", {
      method: "put",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        id: props.tShirts.id,
        size_Id: size,
        style_Id: style,
        manufature_Region: made,
        colour: color,
        gender: gender,
        description: description,
        availablity: true,
        cost: parseInt(price),
        produtionAdditionDate: null,
        productUpdateDate: null,
      }),
    });
    props.updateData();
  }

  async function handleSubmitAdd() {
    await fetch(  process.env.REACT_APP_WEBAPI_URL +"Tshirt", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        id: 0,
        size_Id: size,
        style_Id: style,
        manufature_Region: made,
        product_Image_Name: file.name,
        colour: color,
        gender: gender,
        description: description,
        availablity: true,
        cost: parseInt(price),
        produtionAdditionDate: null,
        productUpdateDate: null,
      }),
    });

    fileUpload();
    props.updateData();
    setAllDataEmpty();
  }

  function setAllDataEmpty() {
    setPrice("");
    setColor("");
    setMade("");
    setGender("");
    setDescription("");
    setSize("");
    setStyle("");
    setFile();
  }

  useEffect(() => {
    fetchAllSize();
    fetchAllStyle();
    setFormData();
    setValidated(false);
  }, []);

  return (
    <>
      <Modal
        show={props.showModalEdit}
        onHide={props.handleCloseModalEdit}
        scrollable={true}
      >
        <Modal.Header closeButton>
          <Modal.Title> {props.formType} Tshirt</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form noValidate validated={validated} onSubmit={handleSubmit}>
            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Size:</Form.Label>
                <Form.Select
                  aria-label="Default select example"
                  value={size}
                  onChange={(e) => {
                    setSize(e.target.value);
                  }}
                  required
                  custom
                >
                  <option value="">Please select valid Size</option>
                  {sizeList.map((data, key) => {
                    return <option value={data.id}>{data.size_Type}</option>;
                  })}
                </Form.Select>
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Size.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Price :</Form.Label>
                <Form.Control
                  type="number"
                  min="0"
                  placeholder="Enter price of T-Shirt"
                  required
                  value={price}
                  onChange={(e) => setPrice(e.target.value)}
                />
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Price.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Color :</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter Color of T-Shirt"
                  required
                  value={color}
                  onChange={(e) => setColor(e.target.value)}
                />
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Color.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Made :</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter the Country where made"
                  required
                  value={made}
                  onChange={(e) => setMade(e.target.value)}
                />
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Made.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Style:</Form.Label>
                <Form.Select
                  aria-label="Default select example"
                  required
                  value={style}
                  onChange={(e) => {
                    setStyle(e.target.value);
                  }}
                  required
                  custom
                >
                  <option value="">Please select a Style</option>
                  {styleList.map((data, key) => {
                    return <option value={data.id}>{data.style_Name}</option>;
                  })}
                </Form.Select>
                <Form.Control.Feedback type="invalid">
                  Please provide a Style.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Gender:</Form.Label>
                {["radio"].map((type) => (
                  <div key={`inline-${type}`} className="mb-2">
                    <Form.Check
                      inline
                      label="Male"
                      name="group1"
                      required
                      type={type}
                      id={`inline-${type}-1`}
                      value="Male"
                      onChange={(e) => setGender(e.target.value)}
                      defaultChecked={maleCheckbox}
                    />
                    <Form.Check
                      inline
                      label="Female"
                      name="group1"
                      type={type}
                      required
                      id={`inline-${type}-2`}
                      value="Female"
                      defaultChecked={femaleCheckbox}
                      onChange={(e) => setGender(e.target.value)}
                    />
                  </div>
                ))}
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Gender.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>

            {props.formType == "Edit" ? (
              <></>
            ) : (
              <>
                <Row className="mb-2">
                  <Form.Group as={Col} md="12" controlId="validationCustom03">
                    <Form.Group controlId="formFile">
                      <Form.Label>Image</Form.Label>
                      <Form.Control
                        type="file"
                        required
                        onChange={(e) => setFile(e.target.files[0])}
                      />
                    </Form.Group>
                    <Form.Control.Feedback type="invalid">
                      Please provide a valid Description.
                    </Form.Control.Feedback>
                  </Form.Group>
                </Row>
              </>
            )}
            <Row className="mb-2">
              <Form.Group as={Col} md="12" controlId="validationCustom03">
                <Form.Label>Description:</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter the Description of the T-Shirt"
                  required
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                />
                <Form.Control.Feedback type="invalid">
                  Please provide a valid Description.
                </Form.Control.Feedback>
              </Form.Group>
            </Row>
            <Modal.Footer>
              <Button variant="secondary" class="btn btn-danger"  onClick={() => { props.handleCloseModalEdit() ; clearFormData()}} >
                Cancel
              </Button>
              {props.formType == "Edit" ? (
                <>
                  {" "}
                  <Button variant="primary" class="mb-2" type="submit">
                    Update
                  </Button>
                </>
              ) : (
                <>
                  {" "}
                  <Button variant="primary" class="m-2" type="submit">
                    Save
                  </Button>
                </>
              )}
            </Modal.Footer>
          </Form>
        </Modal.Body>
      </Modal>
    </>
  );
}
