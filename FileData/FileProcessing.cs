using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    class FileProcessing
    {
        FileData _objFileData;
        FileDetails _objFileDetails;
        string _FileName;

        public FileProcessing(string[] args)
        {
            _FileName = args[1];
            _objFileData = new FileData(args);
            _objFileDetails = new FileDetails();
        }

        public string PopulateFileData()
        {
            string Message = string.Empty;
            string versionorSize = string.Empty;

            try
            {
                Message = _objFileData.ValidateArgs();  //validate arguments...
                if (String.IsNullOrEmpty(Message))
                {
                    versionorSize = _objFileData.CheckForfunctionalityCall();
                    if (versionorSize == FileFunctionEnum.version.ToString())
                        Message = "Version" + _objFileDetails.Version(_FileName);
                    else
                        Message = "Size" + _objFileDetails.Size(_FileName);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return Message;
        }
    }
}
