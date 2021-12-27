import React, { useState } from "react";
import {
  Alert,
  Backdrop,
  Button,
  Card,
  CardActions,
  CardContent,
  CircularProgress,
  Typography,
} from "@mui/material";
import OtpInput from "react-otp-input";
import axios from "axios";
import { useHistory } from "react-router-dom";

export default function OTPVerify({ setStep, storeValue }) {
  const [otp, setOtp] = useState("");
  const [loading, setLoading] = useState(false);
  const [successFeedback, setSucessFeedback] = useState(false);
  const [failedFeedback, setFailedFeedback] = useState(false);

  const history = useHistory();

  const handleChange = (otp) => {
    setOtp(otp);
  };

  const handleGoBack = () => {
    setStep((prevStep) => prevStep - 1);
  };

  const handleRegisterData = () => {
    setLoading(true);
    console.log("storeValue", storeValue);
    axios
      .post(`/api/User/public?code=${otp}`, {
        Name: storeValue.hoTen,
        PhoneNumber: storeValue.soDienThoai,
        Password: storeValue.matKhau,
      })
      .then((res) => {
        setLoading(false);
        setSucessFeedback(true);

        console.log(res);
      })
      .catch((err) => {
        setLoading(false);
        setFailedFeedback(true);
        console.log(err);
      });
  };

  return (
    <div>
      {successFeedback ? (
        <Alert severity="success">Thành công đăng ký tài khoản!</Alert>
      ) : (
        ""
      )}
      {failedFeedback ? (
        <Alert severity="error">Lỗi xác nhận mã xác thực!</Alert>
      ) : (
        ""
      )}
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={loading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
      <Card
        sx={{
          width: 480,
          padding: "2rem",
          margin: "0 auto",
          marginTop: "200px",
          boxShadow: "1px 1px 4px #4d4d5d",
        }}
      >
        <CardContent sx={{ textAlign: "center" }}>
          <Typography
            sx={{
              fontSize: "1.5em",
              fontWeight: "bold",
            }}
          >
            {" "}
            Nhập mã xác nhận
          </Typography>
        </CardContent>

        <CardContent>
          <OtpInput
            value={otp}
            onChange={handleChange}
            numInputs={6}
            containerStyle={{
              justifyContent: "center",
            }}
            inputStyle={{
              width: "3rem",
              height: "3rem",
              margin: "0 1rem",
              fontSize: "2rem",
              borderRadius: "4px",
              border: "1px solid rgba(0,0, 0, 0.3)",
            }}
            separator={<span>-</span>}
          />
        </CardContent>
        <CardActions sx={{ marginTop: "20px", justifyContent: "center" }}>
          <Button variant="contained" color="secondary" onClick={handleGoBack}>
            Quay Lại
          </Button>
          <Button variant="contained" onClick={handleRegisterData}>
            Tiếp Tục
          </Button>
        </CardActions>
      </Card>
    </div>
  );
}
