import styled from "@emotion/styled";
import { css } from "@emotion/react";

const tableStyles = css`
  td,
  th {
    border: 1px solid #ffffff;
    text-align: center;
    padding: 15px;
  }
  tbody td {
    font-size: 18px;
  }
  tr:nth-child(even) {
    background: #d0e4f5;
  }
  thead {
    background: #0b6fa4;
    border-bottom: 5px solid #ffffff;
  }
  thead th {
    font-size: 17px;
    font-weight: bold;
    color: #ffffff;
    text-align: center;
    border-left: 2px solid #ffffff;
  }
`;

export const Table = styled.table`
  width: 90vw;
  margin: auto;
  font-family: "Times New Roman", Times, serif;
  border: 1px solid #ffffff;
  text-align: center;
  border-collapse: collapse;
  ${tableStyles}
`;
