import React from "react";

export default function DescriptionTshirt(props) {
  
  return (
    <>
      <div className="row mt-5">
        <div className="col-md-7">
          <div
            className="card shadow-sm border border-secondary"
            style={{
              borderRadius: "5px",
            }}
          >
            <img
              src={props.avatarImage}
              alt="s"
              class="rounded mx-auto d-block"
              width="200"
              height="200"
            />
          </div>
        </div>
        <div className="col-md-5">
          <div className="row mt-2">
            <div className="col-md-6">Size:</div>
            <div className="col-md-6">{props.size.size_Type}</div>
          </div>

          <div className="row mt-2">
            <div className="col-md-6">Price:</div>
            <div className="col-md-6">${props.tshirtData.cost}</div>
          </div>

          <div className="row mt-2">
            <div className="col-md-6">Color:</div>
            <div className="col-md-6">{props.tshirtData.colour}</div>
          </div>

          <div className="row mt-2">
            <div className="col-md-6">Made:</div>
            <div className="col-md-6">{props.tshirtData.manufature_Region}</div>
          </div>

          <div className="row mt-2">
            <div className="col-md-6">Style:</div>
            <div className="col-md-6">{props.style.style_Name}</div>
          </div>

          <div className="row mt-2">
            <div className="col-md-6">Gender:</div>
            <div className="col-md-6">{props.tshirtData.gender}</div>
          </div>
        </div>
        <div className="row  mt-4">
          {" "}
          <div
            className="card shadow-sm border border-secondary m-3 text-center"
            style={{
              borderRadius: "5px",
            }}
          >
            {props.tshirtData.description}
          </div>
        </div>
      </div>
    </>
  );
}
