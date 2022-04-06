import React from "react";
import Header from "./Header.jsx";
import ContentArea from "./ContentArea.jsx";
import Footer from "./Footer.jsx";
export default function Layout(...rest) {
  return (
    <>
      <Header />
      <ContentArea />
      <Footer />
    </>
  );
}
