import { Alert, Button, Grid, Snackbar, Typography } from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";
import { useParams, useHistory } from "react-router-dom";

const FORM_VALIDATION = yup.object().shape({
  name: yup.string().required("Vui lòng nhập họ và tên"),
  phoneNumber: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng số điện thoại")
    .required("Vui lòng nhập sô điện thoại"),
});

export default function UserEdit() {
  let { id } = useParams();
  const history = useHistory();
  const [serverData, setServerData] = useState({
    id: "",
    name: "",
    phoneNumber: "",
  });
  const [open, setOpen] = useState(false);
  const [fail, setFail] = useState(false);
  const getEditData = () => {
    axios
      .get(`api/User/${id}`)
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

  const handleBack = () => {
    history.goBack();
  };

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
    <div
      style={{
        width: "50%",
        height: "350px",
        border: "1px solid",
        padding: "30px",
        borderRadius: "3px",
      }}
    >
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
          marginBottom: "5px",
          width: 200,
        }}
      >
        Edit User
      </Typography>
      <Formik
        initialValues={serverData}
        validationSchema={FORM_VALIDATION}
        enableReinitialize={true}
        onSubmit={(values) => {
          axios
            .put(`/api/User/${id}`, {
              name: values.name,
              phoneNumber: values.phoneNumber,
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
              name="name"
              label="UserName"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />
            <FastField
              name="phoneNumber"
              label="Số Điện Thoại"
              component={CustomField}
              sx={{ margin: "10px  auto " }}
            />

            {/* <Button variant="contained" type="submit" onClick={handleBack}>
              Back
            </Button> */}
            <Button variant="contained" type="submit">
              Update
            </Button>
          </Form>
        )}
      </Formik>
    </div>
  );
}
