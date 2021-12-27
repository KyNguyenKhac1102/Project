import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import UserTable from "./components/UserTable";

export default function UserPage() {
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
          <UserTable />
        </div>
      </div>
    </div>
  );
}
