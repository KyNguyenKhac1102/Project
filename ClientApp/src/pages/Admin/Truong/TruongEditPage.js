import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import TruongEdit from "./components/TruongEdit";

export default function TruongEditPage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <div
          style={{
            height: 150,
            display: "flex",
            justifyContent: "space-around",
            width: "85%",
            paddingTop: 20,
          }}
        >
          <TruongEdit />
        </div>
      </div>
    </div>
  );
}
