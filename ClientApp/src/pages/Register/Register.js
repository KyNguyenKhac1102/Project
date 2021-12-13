import React, { useState } from "react";
import OTPVerify from "./OTPVerify/OTPVerify";
import RegisterInfo from "./RegisterInfo/RegisterInfo";

export default function Register() {
  const [step, setStep] = useState(0);

  const [storeValue, setStoreValue] = useState({
    hoTen: "",
    soDienThoai: "",
    matKhau: "",
    reMatKhau: "",
  });

  switch (step) {
    case 0:
      return (
        <div>
          <RegisterInfo setStep={setStep} setStoreValue={setStoreValue} />
        </div>
      );
    case 1:
      return (
        <div>
          <OTPVerify setStep={setStep} storeValue={storeValue} />
        </div>
      );
    default:
      return (
        <div>
          <RegisterInfo setStep={setStep} />
        </div>
      );
  }
}
