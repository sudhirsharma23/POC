namespace CP.Core.AdobeSign.Models
{
    public enum AdobeSignEvent
    {
        /// <summary>
        /// A Signing Agreement has been initialized and has been sent to AdobeSign for signing.
        /// Notice that this event will be logged when the "Finished" endpoint is called, and the
        /// adobe_sign_id field is not empty.
        /// </summary>
        AGREEMENT_INITIALIZED,

        /// <summary>
        /// All documents signed. This event will be logged automatically whenever the AdobeSign POST
        /// endpoint is called with the correct documents.
        /// </summary>
        AGREEMENT_SIGNED,

        //
        // UP FOR DEBATE:
        //

        /// <summary>
        /// User abandoned the agreement and refused to sign.
        /// </summary>
        AGREEMENT_ABANDONED,

        /// <summary>
        /// User did not sign document in allocated time.
        /// </summary>
        AGREEMENT_EXPIRED,

        /// <summary>
        /// Agreement was cancelled
        /// </summary>
        AGREEMENT_CANCELLED,

        /// <summary>
        /// Agreement was rejected.
        /// </summary>
        AGREEMENT_REJECTED,

        /// <summary>
        /// Agreement was recalled
        /// </summary>
        AGREEMENT_RECALLED
    }
}