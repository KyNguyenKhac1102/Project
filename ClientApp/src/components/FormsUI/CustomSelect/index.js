import { MenuItem, Select, TextField } from "@mui/material";
import { useFormikContext } from "formik";
import React from "react";

export default function CustomSelect({
  name,
  field,
  form,
  options,
  ...otherProps
}) {
  const configSelect = {
    ...field,
    ...otherProps,
    select: true,
    fullWidth: true,
  };

  if (form.touched[name] && form.errors[name]) {
    configSelect.error = true;
    configSelect.helperText = form.errors[name];
  }

  return (
    <TextField {...configSelect}>
      {Object.keys(options).map((item, pos) => {
        return (
          <MenuItem key={pos} value={item}>
            {options[item]}
          </MenuItem>
        );
      })}
    </TextField>
  );
}
