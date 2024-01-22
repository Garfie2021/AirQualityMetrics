## AirQualityMetrics/Src/

The Windows Form app implemented in Japan's District Ranking with Good Air 2023 has a simple implementation of the processing dialog, and can be used as a reference if you want to quickly implement the processing dialog.
This is helpful if you have a simple implementation of the processing dialog and want to implement the processing dialog quickly.

The processing on the processing dialog side simply displays the value passed to the StatusText property in the txtStatus text box.

If you exclude detailed processing of file operations/DB operations from the click event processing of the "Import CSV file" button and only display confirmation/completion message boxes, task execution, and display/hide processing dialogs, the following will occur.

- Changed btnCsvFileImport_Click button click event handler to an asynchronous method by adding async.
- File import/DB processing is implemented in Task.Run() and executed in a separate thread.
- After starting a task in another thread, display the processing dialog using ProcessingDialog.ShowDialog(), and keep the processing dialog displayed until the await task is finished.
- Each time the number of imported files increases, the progress text is passed to the processingDialog.StatusText property through processingDialog.Invoke().
- By executing processingDialog.Close() through processingDialog.Invoke() during the final processing in Task.Run(), the ProcessingDialog processing dialog is closed when the file import/DB processing is finished.

The original source code, which does not exclude detailed processing of file operations/DB operations from the click event processing of the "Import CSV file" button, is shown below.

[YouTube](https://youtu.be/gh1q7Hn2scU)

[Source code explanation page](https://blog.unikktle.com/windows%e3%83%95%e3%82%a9%e3%83%bc%e3%83%a0%e3%82%a2%e3%83%97%e3%83%aa%e3%81%a7%e5%ae%9f%e8%a3%85%e3%81%99%e3%82%8b%e3%82%b7%e3%83%b3%e3%83%97%e3%83%ab%e3%81%aa%e5%87%a6%e7%90%86%e4%b8%ad%e3%83%80/)

[Source code explanation page](https://blog.unikktle.com/%e7%a9%ba%e6%b0%97%e3%81%8c%e8%89%af%e3%81%84%e6%97%a5%e6%9c%ac%e3%81%ae%e5%9c%b0%e5%8c%ba%e3%83%a9%e3%83%b3%e3%82%ad%e3%83%b3%e3%82%b0-2023%e5%b9%b4/)

---

