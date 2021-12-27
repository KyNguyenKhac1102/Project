import React from "react";

import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import "./Admin.css";
import Card from "@mui/material/Card";
import { CardContent, Typography } from "@mui/material";

export default function Admin() {
  return (
    <div className="Admin">
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />

        <div
          style={{
            minWidth: 250,
            height: 150,
            display: "flex",
            justifyContent: "space-around",
            width: "85%",
            paddingTop: 20,
          }}
        >
          <Card sx={{ minWidth: 250, height: 150 }}>
            <CardContent>
              <Typography
                sx={{ fontSize: 14 }}
                color="text.secondary"
                gutterBottom
              >
                Hồ sơ nhận được
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.primary">
                323
              </Typography>
            </CardContent>
          </Card>
          <Card sx={{ minWidth: 250, height: 150 }}>
            <CardContent>Hồ sơ điểm cao</CardContent>
          </Card>
          <Card sx={{ minWidth: 250, height: 150 }}>
            <CardContent>Hồ sơ ưu tiên</CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
}
