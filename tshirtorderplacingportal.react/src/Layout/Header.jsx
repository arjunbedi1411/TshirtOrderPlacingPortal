import React from "react";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";

export default function Header(...rest) {
  return (
    <>
      <header>
        <div className="navbar navbar-dark bg-dark shadow-sm">
          <div className="container">
            <a className="navbar-brand d-flex align-items-center">
              <ShoppingCartIcon />
              <strong> Tshirt Purchacing Portal</strong>
            </a>
          </div>
        </div>
      </header>
    </>
  );
}
