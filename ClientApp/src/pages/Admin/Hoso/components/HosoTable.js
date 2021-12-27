import React, { useEffect, useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import { Link, useHistory } from "react-router-dom";
import { Button } from "@mui/material";
import doiTuongUuTien from "../../../../data/doiTuongUuTien.json";
import khuVucUuTien from "../../../../data/khuVucUuTien.json";

export default function HosoTable() {
  const [studentInfo, setStudentInfo] = useState([]);
  const history = useHistory();

  const serverDelete = (delete_id) => {
    axios
      .delete(`/api/StudentInfo?id=${delete_id}`, {
        id: delete_id,
      })
      .then((res) => {
        console.log(res);
        getServerData();
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getServerData = () => {
    axios
      .get("/api/StudentInfo")
      .then((res) => {
        setStudentInfo(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const columns = [
    { field: "id", headerName: "ID", width: 100 },
    {
      field: "hoTen",
      headerName: "Họ tên",
      width: 150,
      renderCell: (params) => {
        return <Link to={`/hoso/detail/${params.id}`}>{params.value}</Link>;
      },
    },
    { field: "soDienThoai", headerName: "SĐT", width: 150 },
    { field: "email", headerName: "Email", width: 200 },
    {
      field: "doiTuongId",
      headerName: "Đối tượng",
      width: 250,
      valueGetter: (params) => {
        return doiTuongUuTien[params.value];
      },
    },
    {
      field: "khuVucId",
      headerName: "Khu vực",
      width: 150,
      valueGetter: (params) => {
        return khuVucUuTien[params.value];
      },
    },
    { field: "diemTb_UuTien", headerName: "Điểm", width: 100 },

    // {
    //   field: "edit",
    //   headerName: "",
    //   width: 100,
    //   sortable: false,
    //   renderCell: (params) => {
    //     const handleClick = (e) => {
    //       e.stopPropagation();

    //       const api = params.api;

    //       const thisRow = {};
    //       api
    //         .getAllColumns()
    //         .filter((c) => c.field !== "__check__" && !!c)
    //         .forEach(
    //           (c) => (thisRow[c.field] = params.getValue(params.id, c.field))
    //         );
    //       history.push(`/StudentInfo/edit/${thisRow.id}`);
    //     };
    //     return (
    //       <Button variant="contained" onClick={handleClick}>
    //         Edit
    //       </Button>
    //     );
    //   },
    // },
    {
      field: "delete",
      headerName: "",
      width: 100,
      sortable: false,
      renderCell: (params) => {
        const handleClick = (e) => {
          e.stopPropagation();
          const api = params.api;

          const thisRow = {};
          api
            .getAllColumns()
            .filter((c) => c.field !== "__check__" && !!c)
            .forEach(
              (c) => (thisRow[c.field] = params.getValue(params.id, c.field))
            );
          serverDelete(thisRow.id);
          // getServerData();
        };
        return (
          <Button variant="contained" color="error" onClick={handleClick}>
            Delete
          </Button>
        );
      },
    },
  ];

  useEffect(() => {
    getServerData();
  }, []);
  return (
    <div style={{ height: 500, width: "85%", margin: 20 }}>
      <DataGrid
        rows={studentInfo}
        columns={columns}
        pageSize={7}
        rowsPerPageOptions={[5]}
        checkboxSelection
      />
      {/* <Button
        style={{ margin: 10 }}
        variant="contained"
        onClick={() => {
          history.push("/studentInfo/create");
        }}
      >
        Create
      </Button> */}
    </div>
  );
}
