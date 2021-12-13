import React, { useCallback } from "react";
import { useDropzone } from "react-dropzone";

export default function MyDropzone() {
  const onDrop = useCallback((acceptedFiles) => {
    // Do something with the files
  }, []);
  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop,
  });

  return (
    <div {...getRootProps()}>
      <input {...getInputProps()} />
      {isDragActive ? (
        <p>Kéo file đính kèm...</p>
      ) : (
        <p>Kéo file đính kèm hoặc chọn file...</p>
      )}
    </div>
  );
}
