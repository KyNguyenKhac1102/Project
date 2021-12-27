import Button from "@mui/material/Button";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";

import { Formik, Form, FieldArray, FastField, Field } from "formik";
import * as yup from "yup";
import React, { useEffect, useState } from "react";

import gender from "../../../data/gender.json";
import doiTuongUuTien from "../../../data/doiTuongUuTien.json";
import khuVucUuTien from "../../../data/khuVucUuTien.json";
import maChuyenNganh from "../../../data/maChuyenNganh.json";
import toHop from "../../../data/toHop.json";
import tinhData from "../../../data/tinh.json";

import DateTimePicker from "../../../components/FormsUI/DateTimePicker";

import CloseIcon from "@mui/icons-material/Close";
import {
  Alert,
  Autocomplete,
  Backdrop,
  CircularProgress,
  Input,
  Paper,
  Snackbar,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
} from "@mui/material";
import CustomField from "../../../components/FormsUI/CustomField";
import CustomSelect from "../../../components/FormsUI/CustomSelect";
import CustomAC from "../../../components/FormsUI/CustomAutoComplete";

import axios from "axios";
import CustomSelectTruong from "../../../components/FormsUI/CusomSelectTruong/CustomSelectTruong";
import "./UserInfo.css";

const INIT_FORM_STATE = {
  userId: 5,
  hoTen: "Nguyễn Văn A",
  ngaySinh: "",
  gioiTinh: "Nam",

  SoDienThoai: "09841221412",
  SoCCCD: "0011232421412",
  email: "kynguyenkhac28@gmail.com",
  diaChiHoKhau: "38 Tương Mai, quận Hai Bà Trưng, Hà Nội",
  MaKhuVuc: "3",
  MaDoiTuong: "00",

  Tinh10Id: "1",
  TruongLop10Id: "",

  Tinh11Id: "1",
  TruongLop11Id: "",

  Tinh12Id: "1",
  TruongLop12Id: "",

  diaChiLienHe: "38 Tương Mai, quận Hai Bà Trưng, Hà Nội",

  hoTenBo: "Nguyễn Văn B",
  SdtBo: "0951531531",

  hoTenMe: "Vũ Văn C",
  SdtMe: "09512531531",

  Hocba10_url: "",
  Hocba11_url: "",
  Hocba12_url: "",

  nguyenVongs: [
    {
      maNganh: "",
      maToHop: "",
    },
  ],

  DiemToan10: "1",
  DiemLy10: "1",
  DiemHoa10: "1",

  DiemToan11: "1",
  DiemLy11: "1",
  DiemHoa11: "1",

  DiemToan12: "1",
  DiemLy12: "1",
  DiemHoa12: "1",
};

const FORM_VALIDATION = yup.object().shape({
  hoTen: yup.string().required("Vui lòng nhập họ và tên"),
  ngaySinh: yup.date().required("Vui lòng nhập ngày sinh"),
  gioiTinh: yup.string().required("Vui lòng nhập giới tính"),

  SoDienThoai: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng số điện thoại")
    .required("Vui lòng nhập sô điện thoại"),
  SoCCCD: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng định dạng CCCD/CMND")
    .required("Vui lòng nhập CCCD/CMND"),
  email: yup
    .string()

    .email("Vui lòng nhập đúng định dạng Email")
    .required("Vui lòng nhập Email"),
  diaChiHoKhau: yup
    .string()
    .required("Vui lòng nhập địa chỉ hộ khẩu thường trú"),

  MaKhuVuc: yup.string().required("Vui lòng chọn khu vực"),
  MaDoiTuong: yup.string().required("Vui lòng nhập đối tượng thí sinh"),

  Tinh10Id: yup.string().required("Vui lòng chọn tỉnh lớp 10").nullable(),
  TruongLop10Id: yup.string().required("Vui lòng chọn trường lớp 10"),

  Tinh11Id: yup.string().required("Vui lòng chọn tỉnh lớp 11").nullable(),
  TruongLop11Id: yup.string().required("Vui lòng chọn trường lớp 11"),

  Tinh12Id: yup.string().required("Vui lòng chọn tỉnh lớp 12").nullable(),
  TruongLop12Id: yup.string().required("Vui lòng chọn trường lớp 12"),

  diaChiLienHe: yup.string().required("Vui lòng nhập địa chỉ liên hệ"),
  hoTenBo: yup.string().required("Vui lòng nhập họ và tên Bố"),
  hoTenMe: yup.string().required("Vui lòng nhập họ và tên Mẹ"),
  SdtBo: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng định dạng số điện thoại")
    .required("Vui lòng nhập số điện thoại Bố"),
  SdtMe: yup
    .number()
    .integer()
    .typeError("Vui lòng nhập đúng định dạng số điện thoại")
    .required("Vui lòng nhập số điện thoại Mẹ"),

  DiemToan10: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemLy10: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemHoa10: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),

  DiemToan11: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemLy11: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemHoa11: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),

  DiemToan12: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemLy12: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
  DiemHoa12: yup
    .number()
    .min(0, "Điểm phải lớn hơn 0")
    .max(10, "Điểm phải nhỏ hơn hoặc bằng 10")

    .required("Vui lòng nhập điểm thi"),
});

export default function UserInfo() {
  const [files, setFiles] = useState([]);
  const [truongData, setTruongData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [success, setSuccess] = useState(false);
  const [fail, setFail] = useState(false);
  const [failEmail, setFailEmail] = useState(false);
  const [emailCheck, setEmailCheck] = useState("");
  const [statusEmail, setStatusEmail] = useState("");
  const [open, setOpen] = useState(false);

  const handleFileInputChange10 = (e) => {
    const file = e.target.files[0];

    setFiles([...files, file]);
    console.log(files);
  };

  const handleFileInputChange11 = (e) => {
    const file = e.target.files[0];

    setFiles([...files, file]);
  };

  const handleFileInputChange12 = (e) => {
    const file = e.target.files[0];
    setFiles([...files, file]);
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setSuccess(false);
  };

  const handleCloseFailEmail = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }
    setFailEmail(false);
  };

  const handleCheckEmail = (values) => {
    console.log(values.email);
    const options = {
      method: "GET",
      url: "https://email-checker.p.rapidapi.com/verify/v1",
      params: { email: values.email },
      headers: {
        "x-rapidapi-host": "email-checker.p.rapidapi.com",
        "x-rapidapi-key": "37a28856b7msh8f3b4226e807c49p13ff19jsn38e89890b7b4",
      },
    };

    axios
      .request(options)
      .then(function (response) {
        console.log("check", response);
        //upload to server here
        if (response.data.status === "valid") {
          setOpen(true);
          uploadToServer(values);
        } else if (response.data.status === "invalid") {
          setLoading(false);
          setFailEmail(true);
        }
      })
      .catch(function (error) {
        console.error(error);
      });
  };

  const uploadToServer = (values) => {
    axios
      .post("/api/StudentInfo", values)
      .then((res) => {
        setLoading(false);
        setSuccess(true);
        console.log("info lưu trong db", res.data);
      })
      .catch((err) => {
        setLoading(false);
        setFail(true);
        console.log("server err", err);
      });
  };

  useEffect(() => {
    axios
      .get("/api/Truong")
      .then((res) => {
        console.log("truong", res.data);
        setTruongData(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  useEffect(() => {
    console.log("store", truongData);
  }, [truongData]);

  return (
    <div>
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={loading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>

      <Snackbar
        open={success}
        autoHideDuration={6000}
        onClose={handleClose}
        anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      >
        <Alert onClose={handleClose} severity="success" sx={{ width: "100%" }}>
          Đăng ký xét tuyển thành công!
        </Alert>
      </Snackbar>

      <Snackbar
        open={failEmail}
        autoHideDuration={6000}
        onClose={handleCloseFailEmail}
        anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      >
        <Alert
          onClose={handleCloseFailEmail}
          severity="error"
          sx={{ width: "100%" }}
        >
          Email Failed!
        </Alert>
      </Snackbar>

      {/* {success ? <Alert severity="success">Thành công đăng ký!</Alert> : ""}
      {fail ? <Alert severity="error">Lỗi đăng ký!</Alert> : ""} */}

      <Card sx={{ marginTop: "100px" }}>
        <CardContent>
          <Formik
            initialValues={{ ...INIT_FORM_STATE }}
            validationSchema={FORM_VALIDATION}
            onSubmit={(values) => {
              setLoading(true);

              Promise.all(
                files.map(async (file, index) => {
                  let res;
                  const formData = new FormData();
                  formData.append("file", file);
                  formData.append("upload_preset", "qyheocie");
                  try {
                    res = await axios.post(
                      "https://api.cloudinary.com/v1_1/k9nxk/image/upload",
                      formData
                    );
                    // .then((res) => {
                    //   if (index === 0) {
                    //     console.log("0");
                    //     values["Hocba10_url"] = res.data.secure_url;
                    //   } else if (index === 1) {
                    //     console.log("1");
                    //     values["Hocba11_url"] = res.data.secure_url;
                    //   } else if (index === 2) {
                    //     console.log("2");
                    //     values["Hocba12_url"] = res.data.secure_url;
                    //   }
                    // });
                  } catch (err) {
                    return err;
                  }
                  if (index === 0) {
                    console.log("0");
                    values["Hocba10_url"] = res.data.secure_url;
                  } else if (index === 1) {
                    console.log("1");
                    values["Hocba11_url"] = res.data.secure_url;
                  } else if (index === 2) {
                    console.log("2");
                    values["Hocba12_url"] = res.data.secure_url;
                  }
                  return res;
                })
              ).then((results) => {
                // All the resolved promises returned from the map function.
                console.log("results", results);
                // uploadToServer(values);
                handleCheckEmail(values);
              });

              // files.map((file, index) => {
              //   const formData = new FormData();
              //   formData.append("file", file);
              //   formData.append("upload_preset", "qyheocie");

              //   axios
              //     .post(
              //       "https://api.cloudinary.com/v1_1/k9nxk/image/upload",
              //       formData
              //     )
              //     .then((res) => {
              //       if (index === 0) {
              //         console.log("0");
              //         values["Hocba10_url"] = res.data.secure_url;
              //       } else if (index === 1) {
              //         console.log("1");
              //         values["Hocba11_url"] = res.data.secure_url;
              //       } else if (index === 2) {
              //         console.log("2");
              //         values["Hocba12_url"] = res.data.secure_url;
              //       }
              //     })
              //     .catch((err) => {
              //       console.log("cloud err", err);
              //     });
              // });

              // console.log("values send to server", values);
              // uploadToServer(values);
            }}
          >
            {({ values, isSubmitting, insert, remove, push }) => (
              <Form>
                <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <Typography>
                      <span className="number-part">1</span>{" "}
                      <span className="title-part">Thông tin thí sinh</span>
                    </Typography>
                  </Grid>

                  <Grid item xs={4}>
                    {/* <TextfieldWrapper name="hoTen" label="Họ và tên" /> */}

                    <FastField
                      name="hoTen"
                      label="Họ và tên"
                      component={CustomField}
                    />
                  </Grid>
                  <Grid item xs={2}>
                    <DateTimePicker name="ngaySinh" label="Ngày sinh" />
                  </Grid>
                  <Grid item xs={2}>
                    <FastField
                      name="gioiTinh"
                      label="Giới tính"
                      component={CustomSelect}
                      options={gender}
                    />
                    {/* 
                    <SelectWrapper
                      name="gioiTinh"
                      label="Giới tính"
                      options={gender}
                    /> */}
                  </Grid>
                  <Grid item xs={4}>
                    <FastField
                      name="SoCCCD"
                      label="Số CMND/CCCD"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper name="soCMND" label="Số CMND/CCCD" /> */}
                  </Grid>
                  <Grid item xs={4}>
                    <FastField
                      name="SoDienThoai"
                      label="Số điện thoại"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper name="sdt" label="Số điện thoại" /> */}
                  </Grid>
                  <Grid item xs={4}>
                    <FastField
                      name="email"
                      label="Email"
                      component={CustomField}
                    />
                    {/* {setEmailCheck(values.email)} */}
                    {/* {setTimeout(() => setEmailCheck(values.email), 0)} */}
                    {/* <TextfieldWrapper name="email" label="Email" /> */}
                  </Grid>

                  <Grid item xs={4}>
                    <FastField
                      name="MaDoiTuong"
                      label="Đối tượng"
                      component={CustomSelect}
                      options={doiTuongUuTien}
                    />
                    {/* <SelectWrapper
                      name="doiTuong"
                      label="Đối tượng"
                      options={doiTuongUuTien}
                    /> */}
                  </Grid>
                  <Grid item xs={4}>
                    <FastField
                      name="MaKhuVuc"
                      label="Khu vực"
                      component={CustomSelect}
                      options={khuVucUuTien}
                    />
                    {/* <SelectWrapper
                      name="khuVuc"
                      label="Khu vực"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>
                  <Grid item xs={8}>
                    <FastField
                      name="diaChiHoKhau"
                      label="Địa chỉ Hộ Khẩu"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="diaChiHoKhau"
                      label="Địa chỉ Hộ Khẩu"
                    /> */}
                  </Grid>

                  <Grid item xs={12}>
                    <Typography>
                      <span className="number-part">2</span>
                      <span className="title-part"> Thông tin trường THPT</span>
                    </Typography>
                  </Grid>

                  <Grid item xs={4}>
                    <FastField
                      name="Tinh10Id"
                      label="Mã tỉnh: tên tỉnh lớp 10"
                      component={CustomSelect}
                      options={tinhData}
                    />
                    {/* <SelectWrapper
                      name="lop10.tinh"
                      label="Mã tỉnh: tên tỉnh lớp 10"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={8}>
                    {/* <CustomAC
                      name="TruongLop10Id"
                      options={truongData}
                      label="Trường lớp 10:"
                    /> */}

                    <Field
                      name="TruongLop10Id"
                      label="Trường lớp 10:"
                      component={CustomSelectTruong}
                      options={truongData}
                    />
                    {/* <SelectWrapper
                      name="lop10.truong"
                      label="Trường lớp 10:"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={4}>
                    <FastField
                      name="Tinh11Id"
                      label="Mã tỉnh: tên tỉnh lớp 11"
                      component={CustomSelect}
                      options={tinhData}
                    />
                    {/* <SelectWrapper
                      name="lop11.tinh"
                      label="Mã tỉnh: tên tỉnh lớp 11"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={8}>
                    <Field
                      name="TruongLop11Id"
                      label="Trường lớp 11:"
                      component={CustomSelectTruong}
                      options={truongData}
                    />
                    {/* <SelectWrapper
                      name="lop11.truong"
                      label="Trường lớp 11:"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={4}>
                    <FastField
                      name="Tinh12Id"
                      label="Mã tỉnh: tên tỉnh lớp 12"
                      component={CustomSelect}
                      options={tinhData}
                    />
                    {/* <SelectWrapper
                      name="lop12.tinh"
                      label="Mã tỉnh: tên tỉnh lớp 12"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={8}>
                    <Field
                      name="TruongLop12Id"
                      label="Trường lớp 12:"
                      component={CustomSelectTruong}
                      options={truongData}
                    />
                    {/* <SelectWrapper
                      name="lop12.truong"
                      label="Trường lớp 12:"
                      options={khuVucUuTien}
                    /> */}
                  </Grid>

                  <Grid item xs={12}>
                    <Typography>
                      <span className="number-part">3</span>
                      <span className="title-part"> Thông tin liên hệ</span>
                    </Typography>
                  </Grid>

                  <Grid item xs={12}>
                    <FastField
                      name="diaChiLienHe"
                      label="Địa chỉ liên hệ"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="diaChiLienHe"
                      label="Địa chỉ liên hệ"
                    /> */}
                  </Grid>

                  <Grid item xs={6}>
                    <FastField
                      name="hoTenBo"
                      label="Họ và tên Bố"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="thongTinBo.hoTen"
                      label="Họ và tên Bố"
                    /> */}
                  </Grid>
                  <Grid item xs={6}>
                    <FastField
                      name="SdtBo"
                      label="Số điện thoại Bố"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="thongTinBo.soDienThoai"
                      label="Số điện thoại Bố"
                    /> */}
                  </Grid>

                  <Grid item xs={6}>
                    <FastField
                      name="hoTenMe"
                      label="Họ và tên Mẹ"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="thongTinMe.hoTen"
                      label="Họ và tên Mẹ"
                    /> */}
                  </Grid>
                  <Grid item xs={6}>
                    <FastField
                      name="SdtMe"
                      label="Số điện thoại Mẹ"
                      component={CustomField}
                    />
                    {/* <TextfieldWrapper
                      name="thongTinMe.soDienThoai"
                      label="Số điện thoại Mẹ"
                    /> */}
                  </Grid>

                  <Grid item xs={12}>
                    <Typography>
                      <span className="number-part">4</span>
                      <span className="title-part">
                        {" "}
                        Thông tin đăng ký xét tuyển
                      </span>
                    </Typography>
                  </Grid>
                  <Grid item xs={12}>
                    <Typography>Ảnh học bạ.</Typography>
                  </Grid>

                  {/* <Grid item xs={12}>
                    <input
                      type="file"
                      onChange={(ev) => {
                        console.log(ev.target.files[0]);
                      }}
                    />
                  </Grid> */}
                  <TableContainer component={Paper}>
                    <Table>
                      <TableHead>
                        <TableRow>
                          <TableCell>Học bạ lớp 10</TableCell>
                          <TableCell>Học bạ lớp 11</TableCell>
                          <TableCell>Học bạ lớp 12</TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        <TableRow>
                          <TableCell>
                            <input
                              type="file"
                              name="hocba_10"
                              onChange={handleFileInputChange10}
                            />
                            {/* {previewSource && (
                              <img
                                src={previewSource}
                                alt="hocba_10"
                                style={{ height: 300 }}
                              />
                            )} */}
                          </TableCell>

                          <TableCell>
                            <input
                              type="file"
                              name="hocba_11"
                              onChange={handleFileInputChange11}
                            />
                          </TableCell>
                          <TableCell>
                            <input
                              type="file"
                              name="hocba_12"
                              onChange={handleFileInputChange12}
                            />
                          </TableCell>
                        </TableRow>
                      </TableBody>
                    </Table>
                  </TableContainer>

                  <Grid container item spacing={2}>
                    <FieldArray name="nguyenVongs">
                      {({ insert, push, remove }) => (
                        <>
                          {values.nguyenVongs.length > 0 &&
                            values.nguyenVongs.map((nv, index) => (
                              <Grid container item spacing={2} key={index}>
                                <Grid item xs={1}>
                                  <FastField
                                    name={`nguyenVongs.${index}`}
                                    label={`Nguyện vọng`}
                                    inputProps={{
                                      style: { textAlign: "center" },
                                    }}
                                    value={index + 1}
                                    InputLabelProps={{ shrink: true }}
                                    component={CustomField}
                                  />

                                  {/* <TextfieldWrapper
                                    name={`nguyenVongs.${index}`}
                                    label={`Nguyện vọng`}
                                    inputProps={{
                                      style: { textAlign: "center" },
                                    }}
                                    value={index + 1}
                                    InputLabelProps={{ shrink: true }}
                                  /> */}
                                </Grid>
                                <Grid item xs={6}>
                                  <FastField
                                    name={`nguyenVongs.${index}.maNganh`}
                                    label="Ngành đăng ký"
                                    options={maChuyenNganh}
                                    component={CustomSelect}
                                  />
                                  {/* <SelectWrapper
                                    name={`nguyenVongs.${index}.maChuyenNganh`}
                                    label="Ngành đăng ký"
                                    options={maChuyenNganh}
                                  /> */}
                                </Grid>
                                <Grid item xs={2}>
                                  <FastField
                                    name={`nguyenVongs.${index}.maToHop`}
                                    label="Tổ hợp"
                                    options={toHop}
                                    component={CustomSelect}
                                  />
                                  {/* <SelectWrapper
                                    name={`nguyenVongs.${index}.toHop`}
                                    label="Tổ hợp"
                                    options={toHop}
                                  /> */}
                                </Grid>
                                {values.nguyenVongs &&
                                  values.nguyenVongs.length > 1 && (
                                    <Grid item xs={1}>
                                      <Button
                                        color="inherit"
                                        onClick={() => remove(index)}
                                      >
                                        <CloseIcon />
                                      </Button>
                                    </Grid>
                                  )}
                              </Grid>
                            ))}
                          <Grid item xs={12}>
                            <Button
                              variant="contained"
                              onClick={() =>
                                push({
                                  maNganh: "",
                                  maToHop: "",
                                })
                              }
                            >
                              Thêm nguyện vọng
                            </Button>
                          </Grid>
                        </>
                      )}
                    </FieldArray>
                  </Grid>
                </Grid>

                <TableContainer component={Paper}>
                  <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                      <TableRow>
                        <TableCell>Tên Môn Học</TableCell>
                        <TableCell>Điểm lớp 10</TableCell>
                        <TableCell>Điểm lớp 11</TableCell>
                        <TableCell>Điểm lớp 12</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      <TableRow>
                        <TableCell>Toán</TableCell>
                        <TableCell>
                          <FastField
                            name="DiemToan10"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemToan11"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemToan12"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                      </TableRow>

                      <TableRow>
                        <TableCell>Lý</TableCell>
                        <TableCell>
                          <FastField
                            name="DiemLy10"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemLy11"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemLy12"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                      </TableRow>

                      <TableRow>
                        <TableCell>Hóa</TableCell>
                        <TableCell>
                          <FastField
                            name="DiemHoa10"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemHoa11"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                        <TableCell>
                          <FastField
                            name="DiemHoa12"
                            type="number"
                            InputProps={{
                              inputProps: { min: 0, max: 10, step: "0.1" },
                            }}
                            component={CustomField}
                          />
                        </TableCell>
                      </TableRow>
                    </TableBody>
                  </Table>
                </TableContainer>
                <Button variant="contained" type="submit">
                  Đăng Ký
                </Button>
                <pre>{JSON.stringify(values, null, 2)}</pre>
              </Form>
            )}
          </Formik>
        </CardContent>
        <CardActions></CardActions>
      </Card>
    </div>
  );
}
