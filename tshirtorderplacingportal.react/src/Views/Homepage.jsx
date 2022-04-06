import React from "react";
import AddCircleOutlineIcon from "@material-ui/icons/AddCircleOutline";
import { useEffect, useState } from "react";
import AddEditTshirt from "./AddEditTshirt.jsx";
import CardTshirt from "./CardTshirt.jsx";

export default function Homepage(...rest) {
  const [tshirtList, setTshirtList] = useState([]);
  const [sizeList, setSizeList] = useState([]);
  const [styleList, setStyleList] = useState([]);
  const [formType, setFormType] = useState("Add");
  const [showModalEdit, setShowModalEdit] = useState(false);
  const handleCloseModalEdit = () => setShowModalEdit(false);
  const handleShowModalAdd = () => setShowModalEdit(true);

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

  async function fetchAllTshirts() {
    const tShirts = await fetch(   process.env.REACT_APP_WEBAPI_URL  +"Tshirt").then(
      handleResponse
    );
    setTshirtList(tShirts);
  }

  function updateData() {
    setTshirtList([]);
    fetchAllTshirts();
  }

  useEffect(() => {
    fetchAllTshirts();
  }, []);

  return (
    <>
      <main>
        <section className="py-1 text-center container">
          <div className="row py-lg-1">
            <div className="col-lg-6 col-md-8 mx-auto">
              <h1 className="fw-light">T-Shirt ECommerce</h1>
              <p className="lead text-muted">T-shirts for sale.</p>
            </div>
          </div>
        </section>

        <div className="py-1 bg-light">
          <div className="container">
            <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
              {tshirtList.map((data, key) => {
                return (
                  <div className="col">
                    <CardTshirt
                      tShirts={data}
                      updateData={updateData}
                      styleList={styleList}
                      sizeList={sizeList}
                    />
                  </div>
                );
              })}

              <div className="col text-center ">
                <button
                  type="button"
                  className="btn btn-info btn-lg col-md-4 mt-5"
                  onClick={handleShowModalAdd}
                >
                  <AddCircleOutlineIcon style={{ fontSize: 60 }} />
                </button>
              </div>
            </div>
          </div>
        </div>

        <AddEditTshirt
          updateData={updateData}
          showModalEdit={showModalEdit}
          handleCloseModalEdit={handleCloseModalEdit}
          formType={formType}
        />
      </main>
    </>
  );
}
