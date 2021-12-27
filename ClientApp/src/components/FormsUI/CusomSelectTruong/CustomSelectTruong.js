import { Autocomplete, MenuItem, Select, TextField } from "@mui/material";
import { useField, useFormikContext } from "formik";
import React from "react";

export default function CustomSelectTruong({
  name,
  field,
  form,
  options,
  label,
  ...otherProps
}) {
  const { setFieldValue } = useFormikContext();

  // const handleChange = (newValue) =>{

  // }
  // const [field, meta] = useField(name);
  // console.log("field", field);
  const configSelect = {
    ...field,
    ...otherProps,
    select: true,
    fullWidth: true,
  };

  // const config = {};

  // if (form.touched[name] && form.errors[name]) {
  //   configSelect.error = true;
  //   configSelect.helperText = form.errors[name];
  // }

  return (
    <Autocomplete
      id="controllable-states-demo"
      options={options}
      getOptionLabel={(item) =>
        item.maTruong.concat(" - ", item.tenTruong, " ", item.diaChi)
      }
      onChange={(event, newValue) => {
        // if (newValue.id === null) {
        //   setFieldValue(field.name, "");
        // } else {
        setFieldValue(field.name, newValue.id);
        // }
      }}
      renderInput={(params) => <TextField {...params} label={label} />}
    />
  );
}
