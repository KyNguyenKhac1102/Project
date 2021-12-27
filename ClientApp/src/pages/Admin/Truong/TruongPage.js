import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import TruongTable from "./components/TruongTable";

export default function TruongPage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <TruongTable />
      </div>
    </div>
  );
}
