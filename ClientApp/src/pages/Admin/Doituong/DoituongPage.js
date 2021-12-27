import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import DoituongTable from "./components/DoituongTable";

export default function DoituongPage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <DoituongTable />
      </div>
    </div>
  );
}
