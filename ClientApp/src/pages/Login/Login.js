import React from "react";

import { Link } from "react-router-dom";

import { Formik, Form, Field } from "formik";
import { yup } from "yup";

import TextField from "@mui/material/TextField";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";

import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";

export default function Login() {
  return (
    <div>
      <Card
        sx={{
          width: 460,
          padding: "0.5rem",
          margin: "0 auto",
          marginTop: "150px",
          boxShadow: "1px 1px 4px #4d4d5d",
        }}
      >
        <CardContent
          sx={{
            width: 250,
            margin: "0 auto",
            paddingTop: "30px",
            borderBottom: "1px solid black",
          }}
        >
          <Typography
            sx={{ textAlign: "center", fontSize: 27, fontWeight: 550 }}
          >
            Đăng Nhập
          </Typography>
        </CardContent>
        <CardContent>
          <Formik initialValues={{ phoneNumber: "" }}>
            {({ values, isSubmitting }) => (
              <Form>
                <Field
                  fullWidth
                  label="Số Điện Thoại"
                  name="phone"
                  as={TextField}
                  sx={{ margin: "10px auto" }}
                />
                <Field
                  fullWidth
                  label="Mật Khẩu"
                  name="password"
                  as={TextField}
                  sx={{ margin: "10px auto 0 auto" }}
                />
              </Form>
            )}
          </Formik>
        </CardContent>
        <CardActions>
          <Button variant="contained" fullWidth>
            Đăng Nhập
          </Button>
        </CardActions>
        <CardActions sx={{ justifyContent: "center", marginBottom: "20px" }}>
          <Link to="/qmk">Quên Mật Khẩu</Link>
          <Link to="/register">Đăng Ký</Link>
        </CardActions>
      </Card>
    </div>
  );
}
