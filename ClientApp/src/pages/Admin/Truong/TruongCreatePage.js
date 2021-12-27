import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import TruongCreate from "./components/TruongCreate";

export default function TruongCreatePage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <div
          style={{
            height: 400,
            display: "flex",
            justifyContent: "space-around",
            width: "85%",
            paddingTop: 20,
          }}
        >
          <TruongCreate />
        </div>
      </div>
    </div>
  );
}
