import React from "react";
import { TextField } from "@mui/material";

import { useField, useFormikContext } from "formik";
import DatePicker from "@mui/lab/DatePicker";
import AdapterDateFns from "@mui/lab/AdapterDateFns";

import LocalizationProvider from "@mui/lab/LocalizationProvider";

const DateTimePicker = ({ name, ...otherProps }) => {
  const [field, meta] = useField(name);

  const { setFieldValue } = useFormikContext();

  const handleChange = (value) => {
    console.log(value.toISOString());
    let dateConvert = new Date(value.toString().replace(/-/g, "/"));
    console.log(dateConvert);
    setFieldValue(name, dateConvert);
  };

  const configDateTimePicker = {
    ...field,
    ...otherProps,

    variant: "outlined",
    inputFormat: "dd/MM/yyyy",
    fullWidth: true,
    InputLabelProps: {
      shrink: true,
    },
    onChange: handleChange,
  };

  if (meta && meta.touched && meta.error) {
    configDateTimePicker.error = true;
    configDateTimePicker.helperText = meta.error;
  }

  const [value, setValue] = React.useState(null);

  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <DatePicker
        {...otherProps}
        // {...configDateTimePicker}
        label="Ngày sinh"
        value={value}
        inputFormat="dd/MM/yyyy"
        onChange={(newValue) => {
          setValue(newValue);
          console.log(newValue);
          setFieldValue(name, newValue);
        }}
        renderInput={(params) => <TextField {...params} />}
      />
    </LocalizationProvider>
  );
};

export default DateTimePicker;
