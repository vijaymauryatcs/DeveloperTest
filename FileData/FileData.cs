using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;

namespace FileData
{
    class FileData
    {
        string _Function, _FileName;
        string[] _VersionArgsArr, _SizeArgsArr;
        int _ArgsLength;

        string errorMsgNumOfArguments;
        string errorMsgInvalidVersionOrSize;
        string errorMsgInvalidFilePath;

        public FileData(string[] args)
        {
             _ArgsLength = args.Length;
            _Function = args[0];
            _FileName = args[1];

            //Rettrieve constants from App settings
            _VersionArgsArr = ConfigurationManager.AppSettings["VersionArgsArr"].Split(',');
            _SizeArgsArr = ConfigurationManager.AppSettings["SizeArgsArr"].Split(',');

            errorMsgNumOfArguments = ConfigurationManager.AppSettings["errorMsgNumOfArguments"].ToString();
            errorMsgInvalidVersionOrSize = ConfigurationManager.AppSettings["errorMsgInvalidVersionOrSize"].ToString();
            errorMsgInvalidFilePath = ConfigurationManager.AppSettings["errorMsgInvalidFilePath"].ToString();

        }

        public string ValidateArgs()
        {
            string errMessage = string.Empty;

            if (_ArgsLength != 2)
                errMessage = errorMsgNumOfArguments;

            if (!ValidateFunctionArgs())
                errMessage = errorMsgInvalidVersionOrSize;

            if (!ValidatePath())
                errMessage = errorMsgInvalidFilePath;

            return errMessage;
        }
        //validate if version or size text is provided...
        private Boolean ValidateFunctionArgs()
        {

            if (_VersionArgsArr.Contains(_Function))
                return true;
            else if (_SizeArgsArr.Contains(_Function))
                return true;
            else
                return false;
        }

        //Validate if correct file Path is provided
        private Boolean ValidatePath()
        {
            string ErrorMessage = string.Empty;
            Regex r = new Regex(@"^([a-zA-Z]:/)([a-z_\-\s0-9\.]+)+\.(txt)$");
            Boolean x = r.IsMatch(_FileName);
            return x;
        }

        //Check for which functionality  to call version or size
        public string CheckForfunctionalityCall()
        {
            string versionOrSize = string.Empty;
            if (_VersionArgsArr.Contains(_Function))
                versionOrSize = FileFunctionEnum.version.ToString();
            else if (_SizeArgsArr.Contains(_Function))
                versionOrSize = FileFunctionEnum.size.ToString();
            return versionOrSize;
        }
    }
}
