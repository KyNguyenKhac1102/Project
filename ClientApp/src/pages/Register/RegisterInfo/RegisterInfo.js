import React, { useState } from "react";

import { Link } from "react-router-dom";

import { Formik, Form, Field, FastField } from "formik";
import * as yup from "yup";

import TextField from "@mui/material/TextField";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";

import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import CustomField from "../../../components/FormsUI/CustomField";
import Backdrop from "@mui/material/Backdrop";
import axios from "axios";
import { CircularProgress } from "@mui/material";

const INIT_FORM_STATE = {
  hoTen: "",
  soDienThoai: "",
  matKhau: "",
  reMatKhau: "",
};

const FORM_VALIDATION = yup.object().shape({
  hoTen: yup
    .string()
    .required("Nhập Họ và tên")
    .min(8, "Name should be of minimum 8 characters length"),
  soDienThoai: yup
    .string("Nhập Số điện thoại")
    .min(8, "Password should be of minimum 8 characters length")
    .required("Nhập Số điện thoại"),
  matKhau: yup.string().required("Vui lòng nhập mật khẩu"),
  reMatKhau: yup
    .string()
    .required("Vui lòng xác thực mật khẩu")
    .oneOf([yup.ref("matKhau"), null], "Mật khẩu phải giống nhau"),
});

export default function RegisterInfo({ setStep, setStoreValue }) {
  const [loading, setLoading] = useState(false);

  return (
    <div>
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={loading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
      <Card
        sx={{
          width: 500,
          padding: "0.4rem",
          margin: "0 auto",
          marginTop: "50px",
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
            Đăng Ký
          </Typography>
        </CardContent>
        <CardContent>
          <Formik
            initialValues={{ ...INIT_FORM_STATE }}
            validationSchema={FORM_VALIDATION}
            onSubmit={(values) => {
              console.log(values);
              setLoading(true);
              setStoreValue(values);

              axios
                .post(`/api/User/sendSMS?phone=${values.soDienThoai}`, {
                  phone: values.soDienThoai,
                })
                .then((res) => {
                  console.log(res);
                  setLoading(false);
                  setStep((prevStep) => prevStep + 1);
                })
                .catch((err) => {
                  console.log(err);
                });
            }}
          >
            {({ values, isSubmitting }) => (
              <Form>
                <FastField
                  name="hoTen"
                  label="Họ và tên"
                  component={CustomField}
                  sx={{ margin: "10px  auto " }}
                />
                <FastField
                  name="soDienThoai"
                  label="Số Điện Thoại"
                  component={CustomField}
                  sx={{ margin: "10px  auto " }}
                />
                <FastField
                  name="matKhau"
                  label="Mật Khẩu"
                  type="password"
                  component={CustomField}
                  sx={{ margin: "10px  auto " }}
                />
                <FastField
                  name="reMatKhau"
                  label="Nhập lại mật khẩu"
                  type="password"
                  component={CustomField}
                  sx={{ margin: "10px  auto " }}
                />
                <Button type="submit" variant="contained" fullWidth>
                  Đăng Ký
                </Button>
              </Form>
            )}
          </Formik>
        </CardContent>

        <CardActions sx={{ justifyContent: "center", marginBottom: "20px" }}>
          <Link to="/login">Đăng Nhập</Link>
        </CardActions>
      </Card>
    </div>
  );
}
