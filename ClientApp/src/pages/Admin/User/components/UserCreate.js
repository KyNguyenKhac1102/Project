import { Alert, Button, Grid, Typography } from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";

const INIT_STATE = {
  name: "",
  phoneNumber: "",
  password: "",
};

const FORM_VALIDATION = yup.object().shape({
  name: yup.string().required("Vui lòng nhập họ và tên"),
  phoneNumber: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng số điện thoại")
    .required("Vui lòng nhập sô điện thoại"),
  password: yup.string().required("Vui lòng nhập mật khẩu"),
});

export default function UserCreate() {
  return (
    <div style={{ width: "70%" }}>
      <Typography
        sx={{
          fontSize: 27,
          fontWeight: 550,
          borderBottom: "1px solid",
          paddingBottom: "10px",
          width: 200,
        }}
      >
        User Create
      </Typography>
      <Formik
        initialValues={{ ...INIT_STATE }}
        validationSchema={FORM_VALIDATION}
        onSubmit={(values) => {
          axios
            .post("/api/User/private", values)
            .then((res) => {
              console.log(res.data);
            })
            .catch((err) => {
              console.log(err);
            });
        }}
      >
        {({ values, isSubmitting }) => (
          <Form>
            <FastField
              name="name"
              label="Họ và tên"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />
            <FastField
              name="phoneNumber"
              label="Số Điện Thoại"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />
            <FastField
              name="password"
              label="Mật Khẩu"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />

            <Button variant="contained" type="submit">
              Create
            </Button>
          </Form>
        )}
      </Formik>
    </div>
  );
}
