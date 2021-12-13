import { TextField } from "@mui/material";
import { ErrorMessage } from "formik";
import React from "react";

export default function CustomField({ field, form, ...otherProps }) {
  const { name } = field;

  const configTextfield = {
    ...field,
    ...otherProps,
    fullWidth: true,
  };

  if (form.touched[name] && form.errors[name]) {
    configTextfield.error = true;
    configTextfield.helperText = form.errors[name];
  }

  return <TextField {...configTextfield} />;
}
