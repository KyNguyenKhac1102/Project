import {
  Alert,
  Button,
  Card,
  CardContent,
  CardMedia,
  Grid,
  Modal,
  Snackbar,
  TextField,
  Typography,
} from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";
import { useParams } from "react-router-dom";
import doiTuongUuTien from "../../../../data/doiTuongUuTien.json";
import khuVucUuTien from "../../../../data/khuVucUuTien.json";
import tinh from "../../../../data/tinh.json";
import maChuyenNganh from "../../../../data/maChuyenNganh.json";
import toHop from "../../../../data/toHop.json";
import "./HosoDetail.css";
import { Box } from "@mui/system";

const styleModal = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
};

export default function HosoDetail() {
  let { id } = useParams();

  const [serverData, setServerData] = useState({
    id: "",
    userId: "",
    hoTen: "",
    ngaySinh: "",
    gioiTinh: "",

    soDienThoai: "",
    soCCCD: "",
    email: "",
    diaChiHoKhau: "",
    khuVucId: "",
    doiTuongId: "",

    tinh10Id: "",
    truongLop10Id: "",

    tinh11Id: "",
    truongLop11Id: "",

    tinh12Id: "",
    truongLop12Id: "",

    diaChiLienHe: "",

    hoTenBo: "",
    sdtBo: "",

    hoTenMe: "",
    sdtMe: "",

    hocba10_url: "",
    hocba11_url: "",
    hocba12_url: "",

    studentNguyenVongs: [
      {
        stt_NguyenVong: "",
        maNganh: "",
        maToHop: "",
      },
    ],

    diemToan10: "",
    diemLy10: "",
    diemHoa10: "",

    diemToan11: "",
    diemLy11: "",
    diemHoa11: "",

    diemToan12: "",
    diemLy12: "",
    diemHoa12: "",
    diemTb_UuTien: "",
  });

  const [truong10, setTruong10] = useState("");
  const [truong11, setTruong11] = useState("");
  const [truong12, setTruong12] = useState("");

  const [open, setOpen] = React.useState(false);
  const [open11, setOpen11] = React.useState(false);
  const [open12, setOpen12] = React.useState(false);
  const handleOpen = () => {
    setOpen(true);
  };
  const handleOpen11 = () => {
    setOpen11(true);
  };
  const handleOpen12 = () => {
    setOpen12(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
  const handleClose11 = () => {
    setOpen11(false);
  };
  const handleClose12 = () => {
    setOpen12(false);
  };

  const getHosoDetail = () => {
    axios
      .get(`api/StudentInfo/${id}`)
      .then((res) => {
        console.log(res.data);

        setServerData(res.data);

        getTruong10ById(res.data.truongLop10Id);
        getTruong11ById(res.data.truongLop11Id);
        getTruong12ById(res.data.truongLop12Id);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getTruong10ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong10(res.data.tenTruong);
    });
  };

  const getTruong11ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong11(res.data.tenTruong);
    });
  };

  const getTruong12ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong12(res.data.tenTruong);
    });
  };

  useEffect(() => {
    getHosoDetail();
  }, []);

  return (
    <>
      {" "}
      <Modal open={open} onClose={handleClose}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba10_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <Modal open={open11} onClose={handleClose11}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba11_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <Modal open={open12} onClose={handleClose12}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba12_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <div
        style={{
          height: "90%",
          width: "85%",
          paddingTop: 20,
          paddingLeft: 50,
        }}
      >
        <Typography
          sx={{
            fontSize: 24,
            fontWeight: 550,
            borderBottom: "1px solid",
            paddingBottom: "5px",
            width: 200,
          }}
        >
          Ho So Detail
        </Typography>
        {/* <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <Typography>Thông tin thí sinh</Typography>
                  </Grid>
                  </Grid> */}
        <div style={{ display: "flex" }} className="flex-container">
          <div>
            {" "}
            <div className="title">THÔNG TIN CÁ NHÂN</div>
            <Typography>ID: {serverData.id}</Typography>
            <Typography>Họ tên: {serverData.hoTen}</Typography>
            <Typography>Ngày sinh: {serverData.ngaySinh}</Typography>
            <Typography>Giới tính: {serverData.gioiTinh}</Typography>
            <Typography>Số CMND/CCCD: {serverData.soCCCD}</Typography>
            <Typography>Số Điện Thoại: {serverData.soDienThoai}</Typography>
            <Typography>Địa chỉ hộ khẩu: {serverData.diaChiHoKhau}</Typography>
            <Typography>
              Đối tượng: {doiTuongUuTien[serverData.doiTuongId]}
            </Typography>
            <Typography>
              Khu Vực: {khuVucUuTien[serverData.khuVucId]}
            </Typography>
            <div className="title">THÔNG TIN TRƯỜNG</div>
            <Typography>Tỉnh lớp 10: {tinh[serverData.tinh10Id]}</Typography>
            <Typography>Tỉnh lớp 11: {tinh[serverData.tinh11Id]}</Typography>
            <Typography>Tỉnh lớp 12: {tinh[serverData.tinh12Id]}</Typography>
            <Typography>Trường lớp 10: {truong10}</Typography>
            <Typography>Trường lớp 11: {truong11}</Typography>
            <Typography>Trường lớp 12: {truong12}</Typography>
          </div>
          <div>
            <div className="title">THÔNG TIN LIÊN HỆ</div>
            <Typography>Địa chỉ liên hệ: {serverData.diaChiLienHe}</Typography>
            <Typography>Họ tên bố: {serverData.hoTenBo}</Typography>
            <Typography>Số điện thoại Bố: {serverData.sdtBo}</Typography>
            <Typography>Họ tên Mẹ: {serverData.hoTenMe}</Typography>
            <Typography>Số điện thoại Mẹ: {serverData.sdtMe}</Typography>
            <div className="title-diem">ĐIỂM</div>
            <div style={{ display: "flex", justifyContent: "space-between" }}>
              <div className="diem-container">
                <Typography>Điểm Toán 10: {serverData.diemToan10}</Typography>
                <Typography>Điểm Lý 10: {serverData.diemLy10}</Typography>
                <Typography>Điểm Hóa 10: {serverData.diemHoa10}</Typography>
                <Typography>Điểm Toán 11: {serverData.diemToan11}</Typography>
                <Typography>Điểm Lý 11: {serverData.diemLy11}</Typography>
                <Typography>Điểm Hóa 11: {serverData.diemHoa11}</Typography>
                <Typography>Điểm Toán 12:{serverData.diemToan12}</Typography>
                <Typography>Điểm Lý 12: {serverData.diemLy12}</Typography>
                <Typography>Điểm Hóa 12: {serverData.diemHoa12}</Typography>
              </div>
              <div className="tongdiem-container">
                <h5>Điểm xét tuyển:</h5>
                <div>{serverData.diemTb_UuTien}</div>
              </div>
            </div>
          </div>
        </div>
        <div>
          <div className="title-2">NGUYỆN VỌNG</div>
          {serverData.studentNguyenVongs.map((nv, index) => (
            <div key={nv.stt_NguyenVong} className="nguyenvong-container">
              <TextField value={nv.stt_NguyenVong} label="Nguyen Vong" />
              <TextField
                value={maChuyenNganh[nv.maNganh]}
                label="Nganh"
                style={{ paddingLeft: 5, width: 450 }}
              />
              <TextField
                value={toHop[nv.maToHop]}
                label="To Hop"
                className="space"
                style={{ paddingLeft: 5 }}
              />
            </div>
          ))}
        </div>
        <div>
          <div className="title-2"> ẢNH HỌC BẠ </div>
        </div>

        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            width: "85%",
          }}
        >
          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba10_url}
              alt="hocba10"
              onClick={handleOpen}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                Học bạ lớp 10
              </Typography>
            </CardContent>
          </Card>

          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba11_url}
              alt="hocba11"
              onClick={handleOpen11}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                Học bạ lớp 11
              </Typography>
            </CardContent>
          </Card>

          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba12_url}
              alt="hocba12"
              onClick={handleOpen12}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                Học bạ lớp 12
              </Typography>
            </CardContent>
          </Card>
        </div>
      </div>
    </>
  );
}
