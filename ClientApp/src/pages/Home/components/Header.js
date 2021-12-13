import React from "react";

import { AppBar, Button, Toolbar, Typography } from "@mui/material";
export default function Header() {
  return (
    <AppBar>
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Đăng Ký Xét Tuyển
        </Typography>
        <Button color="inherit">Đăng Xuất</Button>
      </Toolbar>
    </AppBar>
  );
}
