import { Alert, Button, Grid, Typography } from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";

const INIT_STATE = {
  maTruong: "",
  tenTruong: "",
  diaChi: "",
};

const FORM_VALIDATION = yup.object().shape({
  maTruong: yup.string().required("Vui lòng nhập mã trường"),
  tenTruong: yup.string().required("Vui lòng nhập tên trường"),

  diaChi: yup.string().required("Vui lòng nhập địa chỉ"),
});

export default function TruongCreate() {
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
        Truong Create
      </Typography>
      <Formik
        initialValues={{ ...INIT_STATE }}
        validationSchema={FORM_VALIDATION}
        onSubmit={(values) => {
          axios
            .post("/api/Truong", values)
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
              name="maTruong"
              label="Mã Trường"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />
            <FastField
              name="tenTruong"
              label="Tên Trường"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />
            <FastField
              name="diaChi"
              label="Địa Chỉ"
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
