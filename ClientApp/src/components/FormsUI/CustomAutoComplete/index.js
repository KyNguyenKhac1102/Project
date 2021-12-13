import React from "react";
import { useField } from "formik";
import { Autocomplete, TextField } from "@mui/material";
import { useFormikContext } from "formik";

export default function CustomAC({ name, label, options, ...otherProps }) {
  const [field, meta] = useField(name);
  const { setFieldValue, initialValues } = useFormikContext();

  //   console.log(useField(name));
  //   console.log(useFormikContext());

  const configAC = {
    ...field,
    ...otherProps,
    fullWidth: true,
    variant: "outlined",
  };

  if (meta && meta.touched && meta.error) {
    configAC.error = true;
    configAC.helperText = meta.error;
  }
  console.log(meta);
  return (
    <Autocomplete
      {...configAC}
      id={name}
      options={options}
      // onChange={(e, value) => {
      //   console.log("value", value);
      //   setFieldValue(name, value);
      // }}
      renderInput={(params) => (
        <TextField {...params} label={label} name={name} />
      )}
    />
  );
}
