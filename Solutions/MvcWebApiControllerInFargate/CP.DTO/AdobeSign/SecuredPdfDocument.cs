using CP.DTO.WorkflowFinished;
using FirstAmerican.Common;
using FirstAmerican.Common.Exceptions;
using System;
using System.Linq;

namespace CP.DTO.AdobeSign
{
    public class SecuredPdfDocument
    {
        /// <summary>
        /// The document name, cleaned.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Pdf Binary
        /// </summary>
        public byte[] Pdf { get; private set; }

        /// <summary>
        /// The Calculated Sha256 Hash
        /// </summary>
        public byte[] Sha256Hash { get; private set; }

        /// <summary>
        /// A clean label, containing only ASCII characters and underscores.
        /// This would be appropriate, for example, to embed into raw HTML
        /// code without fear of it having any side effects.
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// The Document instance from which this SecuredPdfDocument is derived.
        /// </summary>
        public Document SourceDocument { get; private set; }

        /// <summary>
        /// Given an unvalidated Document, ensure that the supplied SHA256 Hash matches a calculated document hash.
        /// Also clean up the document name, removing any unprintable characters that may cause trouble.
        /// Once the above has been completed, ensure that the supplied binary document is truly a PDF document.
        /// </summary>
        /// <param name="cfwfId">Consumer File Workflow Id.</param>
        /// <param name="doc">The document to validate.</param>
        /// <returns>The validated document.</returns>
        public static SecuredPdfDocument ValidateUnsecuredDocument(int cfwfId, Document doc)
        {
            if (doc == null)
            {
                throw new ArgumentException("Missing document for cfwfId {cfwfId}");
            }

            string documentName = doc.Name; //StringUtil.CleanString(doc.Name);
            if (string.IsNullOrWhiteSpace(documentName))
            {
                throw new ArgumentException("Document name is missing for cfwfId {cfwfId}");
            }
            if (doc.Binary == null)
            {
                throw new ArgumentException($"Missing binary for '{documentName}' for cfwfId {cfwfId}");
            }

            byte[] documentByteArray = Convert.FromBase64String(doc.Binary);
            byte[] calculatedHash = CryptographyManager.CreateHash(HashAlgorithmType.SHA256, documentByteArray);

            if (!calculatedHash.SequenceEqual(doc.Sha256Hash))
            {
                throw new DocumentHashMismatch($"Hashes do not match for '{documentName}' for cfwfId '{cfwfId}'");
            }

            //if (!FilesystemOperations.IsDataStreamMatchingFileType(PDF_EXTENSION, documentByteArray))
            //{
            //    throw new DocumentDataStreamMismatch($"The supplied document, '{documentName}', is not a valid PDF document for cfwfId {cfwfId}.");
            //}

            return new SecuredPdfDocument
            {
                Name = documentName,
                Pdf = documentByteArray,
                Sha256Hash = calculatedHash,
                Tag = documentName, //StringUtil.ConvertStringToLabel(documentName),
                SourceDocument = doc
            };
        }
    }
}