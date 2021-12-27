import React from "react";

import { AppBar, Box, Button, Toolbar, Typography } from "@mui/material";
export default function Header() {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Admin Page
        </Typography>
        <Button color="inherit">Đăng Xuất</Button>
      </Toolbar>
    </AppBar>
  );
}
