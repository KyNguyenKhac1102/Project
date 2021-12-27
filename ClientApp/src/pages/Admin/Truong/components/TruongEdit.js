import { Alert, Button, Grid, Snackbar, Typography } from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";
import { useParams } from "react-router-dom";

const FORM_VALIDATION = yup.object().shape({
  maTruong: yup.string().required("Vui lòng nhập mã trường"),
  tenTruong: yup.string().required("Vui lòng nhập tên trường"),
  diaChi: yup.string().required("Vui lòng nhập địa chỉ"),
});

export default function TruongEdit() {
  let { id } = useParams();

  const [serverData, setServerData] = useState({
    id: "",
    maTruong: "",
    tenTruong: "",
    diaChi: "",
  });
  const [open, setOpen] = useState(false);
  const [fail, setFail] = useState(false);
  const getEditData = () => {
    axios
      .get(`api/Truong/${id}`)
      .then((res) => {
        setServerData(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    getEditData();
  }, []);

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };
  const handleCloseFail = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setFail(false);
  };
  return (
    <div style={{ width: "70%" }}>
      <Snackbar
        open={open}
        autoHideDuration={6000}
        onClose={handleClose}
        anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      >
        <Alert onClose={handleClose} severity="success" sx={{ width: "100%" }}>
          Edit success!
        </Alert>
      </Snackbar>
      <Snackbar
        open={fail}
        autoHideDuration={6000}
        onClose={handleCloseFail}
        anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      >
        <Alert
          onClose={handleCloseFail}
          severity="error"
          sx={{ width: "100%" }}
        >
          Error!
        </Alert>
      </Snackbar>
      <Typography
        sx={{
          fontSize: 27,
          fontWeight: 550,
          borderBottom: "1px solid",
          paddingBottom: "10px",
          width: 200,
        }}
      >
        Truong Edit
      </Typography>
      <Formik
        initialValues={serverData}
        validationSchema={FORM_VALIDATION}
        enableReinitialize={true}
        onSubmit={(values) => {
          axios
            .put(`/api/Truong/${id}`, {
              maTruong: values.maTruong,
              tenTruong: values.tenTruong,
              diaChi: values.diaChi,
            })
            .then((res) => {
              console.log(res.data);
              setOpen(true);
            })
            .catch((err) => {
              console.log(err);
              setFail(true);
            });
        }}
      >
        {({ values, isSubmitting }) => (
          <Form>
            <FastField
              name="id"
              label="ID"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
              disabled
            />
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
              Update
            </Button>
          </Form>
        )}
      </Formik>
    </div>
  );
}
