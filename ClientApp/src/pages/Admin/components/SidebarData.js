import React from "react";
import AdminPanelSettingsIcon from "@mui/icons-material/AdminPanelSettings";
import ArticleIcon from "@mui/icons-material/Article";
import DashboardIcon from "@mui/icons-material/Dashboard";
import SchoolIcon from "@mui/icons-material/School";
import AssignmentIcon from "@mui/icons-material/Assignment";
import AccountBoxIcon from "@mui/icons-material/AccountBox";
import AccessibleForwardIcon from "@mui/icons-material/AccessibleForward";
import AddLocationIcon from "@mui/icons-material/AddLocation";

export const SidebarData = [
  {
    icon: <DashboardIcon />,
    title: "Dashboard",
    link: "/admin",
  },
  {
    icon: <AccountBoxIcon />,
    title: "User",
    link: "/user",
  },
  {
    icon: <ArticleIcon />,
    title: "Hồ Sơ",
    link: "/hoso",
  },
  {
    icon: <SchoolIcon />,
    title: "Trường",
    link: "/truong",
  },
  {
    icon: <AssignmentIcon />,
    title: "Ngành",
    link: "/nganh",
  },
  {
    icon: <AccessibleForwardIcon />,
    title: "Đối tượng",
    link: "/doituong",
  },
  {
    icon: <AddLocationIcon />,
    title: "Khu vực",
    link: "/khuvuc",
  },
];
