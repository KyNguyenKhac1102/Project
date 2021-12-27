import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import HosoTable from "./components/HosoTable";

export default function HosoPage() {
  return (
    <div style={{ width: "auto", height: "100vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <HosoTable />
      </div>
    </div>
  );
}
