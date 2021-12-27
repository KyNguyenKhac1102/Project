import React, { useEffect, useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import { useHistory } from "react-router-dom";
import { Button } from "@mui/material";

export default function TruongTable() {
  const [truongData, setTruongData] = useState([]);
  const history = useHistory();

  const serverDelete = (delete_id) => {
    axios
      .delete(`/api/Truong?id=${delete_id}`, {
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
      .get("/api/Truong")
      .then((res) => {
        setTruongData(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const columns = [
    { field: "id", headerName: "ID", width: 50 },
    { field: "maTruong", headerName: "Mã Trường", width: 100 },
    { field: "tenTruong", headerName: "Tên Trường", width: 250 },
    { field: "diaChi", headerName: "Địa Chỉ", width: 600 },

    {
      field: "edit",
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
          history.push(`/truong/edit/${thisRow.id}`);
        };
        return (
          <Button variant="contained" onClick={handleClick}>
            Edit
          </Button>
        );
      },
    },
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
        rows={truongData}
        columns={columns}
        pageSize={7}
        rowsPerPageOptions={[5]}
        checkboxSelection
      />
      <Button
        style={{ margin: 10 }}
        variant="contained"
        onClick={() => {
          history.push("/truong/create");
        }}
      >
        Create
      </Button>
    </div>
  );
}
