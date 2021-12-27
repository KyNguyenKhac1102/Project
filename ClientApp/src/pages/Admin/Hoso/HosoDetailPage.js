import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import HosoDetail from "./components/HosoDetail";

export default function HosoDetailPage() {
  return (
    <div style={{ width: "auto", height: "160vh" }}>
      <Header />
      <div style={{ display: "flex", height: "100%" }}>
        <Sidebar />
        <HosoDetail />
      </div>
    </div>
  );
}
