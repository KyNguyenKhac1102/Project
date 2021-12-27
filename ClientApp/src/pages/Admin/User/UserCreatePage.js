import React from "react";
import Header from "../components/Header";
import Sidebar from "../components/Sidebar";
import UserCreate from "./components/UserCreate";

export default function UserCreatePage() {
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
          <UserCreate />
        </div>
      </div>
    </div>
  );
}
