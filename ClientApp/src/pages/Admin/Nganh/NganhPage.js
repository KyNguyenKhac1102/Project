import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";

export default function NganhPage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        usershit
      </div>
    </div>
  );
}
