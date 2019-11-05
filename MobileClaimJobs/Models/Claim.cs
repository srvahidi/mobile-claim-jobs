using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileClaimJobs.Models
{
    public class Claim
    {
        [Display(Name = "id")]
        [BsonElement("_id", Order = 1)]
        public BsonObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the claim number.
        /// </summary>
        /// <value>The claim number.</value>
        public string claimNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string partnerDataUrl { get; set; }

        /// <summary>
        /// Gets or sets the communication preference.
        /// </summary>
        /// <value>The communication preference.</value>
        public int communicationPreference { get; set; }

        /// <summary>
        /// Gets or sets the customer status.
        /// </summary>
        /// <value>The customer status.</value>
        [Display(Name = "customerStatus")]
        public int customerStatus { get; set; }

        /// <summary>
        /// Gets or sets the deductible.
        /// </summary>
        /// <value>The deductible.</value>
        [Required]
        public string deductible { get; set; }

        /// <summary>
        /// Gets or sets the org identifier.
        /// </summary>
        /// <value>The org identifier.</value>
        [Required]
        public string orgId { get; set; }

        /// <summary>
        /// Gets or sets the responsible root org member identifier.
        /// </summary>
        /// <value>The responsible root org member identifier.</value>
        public string responsibleRootOrgMemberId { get; set; }

        /// <summary>
        /// Gets or sets the responsible organization member identifier.
        /// </summary>
        /// <value>The responsible organization member identifier.</value>
        public string responsibleOrganizationMemberId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>The task identifier.</value>
        public string taskId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle file identifier.
        /// </summary>
        /// <value>The vehicle file identifier.</value>
        public string vehicleFileId { get; set; }

        /// <summary>
        /// Gets or sets the sent reminder.
        /// </summary>
        /// <value>The sent reminder.</value>
        public int sentReminder { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string userName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string password { get; set; }

        /// <summary>
        /// Gets or sets the password sent date.
        /// </summary>
        /// <value>The password sent date.</value>
        public DateTime passwordSentDate { get; set; }

        /// <summary>
        /// Gets or sets the staff appraiser cell phone.
        /// </summary>
        /// <value>The staff appraiser cell phone.</value>
        public string staffAppraiserCellPhone { get; set; }

        /// <summary>
        /// Gets or sets the staff appraiser email address.
        /// </summary>
        /// <value>The staff appraiser email address.</value>
        public string staffAppraiserEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the staff appraiser last.
        /// </summary>
        /// <value>The name of the staff appraiser last.</value>
        public string staffAppraiserLastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the staff appraiser first.
        /// </summary>
        /// <value>The name of the staff appraiser first.</value>
        public string staffAppraiserFirstName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MBEWrapperAPI.Models.ClaimInputs"/> mobile
        /// estimate indicator.
        /// </summary>
        /// <value><c>true</c> if mobile estimate indicator; otherwise, <c>false</c>.</value>
        public bool mobileEstimateIndicator { get; set; }

        /// <summary>
        /// Gets or sets the role code.
        /// </summary>
        /// <value>The role code.</value>
        public string roleCode { get; set; }

        /// <summary>
        /// Gets or sets the business category.
        /// </summary>
        /// <value>The business category.</value>
        public string businessCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MBEWrapperAPI.Models.ClaimInputs"/> is password expired.
        /// </summary>
        /// <value><c>true</c> if is password expired; otherwise, <c>false</c>.</value>
        public bool isPasswordExpired { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime createdDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime updatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MBEWrapperAPI.Models.ClaimInputs"/> is user assigned.
        /// </summary>
        /// <value><c>true</c> if is user assigned; otherwise, <c>false</c>.</value>
        public bool isUserAssigned { get; set; }

        /// <summary>
        /// Gets or sets the estimate sent reminder.
        /// </summary>
        /// <value>The estimate sent reminder.</value>
        public int estimateSentReminder { get; set; }

        /// <summary>
        /// Gets or sets the login noaction sent reminder.
        /// </summary>
        /// <value>The login noaction sent reminder.</value>
        public int loginNoactionSentReminder { get; set; }

        /// <summary>
        /// Gets or sets the no photos sent reminder.
        /// </summary>
        /// <value>The no photos sent reminder.</value>
        public int noPhotosSentReminder { get; set; }

        /// <summary>
        /// Gets or sets the photos no submit sent reminder.
        /// </summary>
        /// <value>The photos no submit sent reminder.</value>
        public int photosNoSubmitSentReminder { get; set; }

        /// <summary>
        /// Gets or sets the assignment note.
        /// </summary>
        /// <value>The assignment note.</value>
        public string assignmentNote { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle owner first.
        /// </summary>
        /// <value>The name of the vehicle owner first.</value>
        public string vehicleOwnerFirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the vehicle owner last.
        /// </summary>
        /// <value>The name of the vehicle owner last.</value>
        public string vehicleOwnerLastName { get; set; }

        /// <summary>
        /// Gets or sets the vehicle owner email.
        /// </summary>
        /// <value>The vehicle owner email.</value>
        public string vehicleOwnerEmail { get; set; }

        /// <summary>
        /// Gets or sets the vehicle owner cell phone.
        /// </summary>
        /// <value>The vehicle owner cell phone.</value>
        public string vehicleOwnerCellPhone { get; set; }

        /// <summary>
        /// Gets or sets the estimate net total.
        /// </summary>
        /// <value>The estimate net total.</value>
        public double estimateNetTotal { get; set; }

        /// <summary>
        /// Gets or sets the parse object identifier.
        /// </summary>
        /// <value>The parse object identifier.</value>
        public string ParseObjectId { get; set; }

        /// <summary>
        /// Gets or sets the claim note.
        /// </summary>
        /// <value>The claim note.</value>
        public string ClaimNote { get; set; }

        /// <summary>
        /// Gets or sets the work assignment pk.
        /// </summary>
        /// <value>The work assignment pk.</value>
        public string workAssignmentPK { get; set; }

        /// <summary>
        /// Gets or sets the estimate sent date.
        /// </summary>
        /// <value>The estimate sent date.</value>
        public string EstimateSentDate { get; set; }

        /// <summary>
        /// Gets or sets the vehicle vin.
        /// </summary>
        /// <value>The vehicle vin.</value>
        public string vehicleVIN { get; set; }

        /// <summary>
        /// Gets or sets the vehicle style code.
        /// </summary>
        /// <value>The vehicle style code.</value>
        public string vehicleStyleCode { get; set; }

        /// <summary>
        /// Gets or sets the  style edition year code.
        /// </summary>
        /// <value>The style edition year code.</value>
        public string styleEditionYearCode { get; set; }

        /// <summary>
        /// Gets or sets the estimate vehicle vin.
        /// </summary>
        /// <value>The estimate vehicle vin.</value>
        public string estimateVehicleVIN { get; set; }

        /// <summary>
        /// Gets or sets the estimate vehicle make.
        /// </summary>
        /// <value>The estimate vehicle make.</value>
        public string estimateVehicleMake { get; set; }

        /// <summary>
        /// Gets or sets the estimate vehicle model.
        /// </summary>
        /// <value>The estimate vehicle model.</value>
        public string estimateVehicleModel { get; set; }

        /// <summary>
        /// Gets or sets the estimate vehicle year.
        /// </summary>
        /// <value>The estimate vehicle year.</value>
        public string estimateVehicleYear { get; set; }

        /// <summary>
        /// Gets or sets the assignment vehicle make.
        /// </summary>
        /// <value>The assignment vehicle make.</value>
        public string assignmentVehicleMake { get; set; }

        /// <summary>
        /// Gets or sets the assignment vehicle model.
        /// </summary>
        /// <value>The assignment vehicle model.</value>
        public string assignmentVehicleModel { get; set; }

        /// <summary>
        /// Gets or sets the assignment vehicle year.
        /// </summary>
        /// <value>The assignment vehicle year.</value>
        public string assignmentVehicleYear { get; set; }

        /// <summary>
        /// Gets or sets the vehicle number.
        /// </summary>
        /// <value>The vehicle number.</value>
        public string vehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the mobile estimate.
        /// </summary>
        /// <value>The type of the mobile estimate.</value>
        public string mobileEstimateType { get; set; }

        /// <summary>
        /// Gets or sets the external identifier.
        /// </summary>
        /// <value>The external identifier.</value>
        public string externalId { get; set; }

        /// <summary>
        /// Gets or sets the type of the loss.
        /// </summary>
        /// <value>The type of the loss.</value>
        public string lossType { get; set; }

        /// <summary>
        /// Gets or sets the loss date.
        /// </summary>
        /// <value>The loss date.</value>
        public DateTime? lossDate { get; set; }

        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>The mileage.</value>
        public string mileage { get; set; }

        /// <summary>
        /// Gets or sets the type of the inspection.
        /// </summary>
        /// <value>The type of the inspection.</value>
        public string inspectionType { get; set; }

        /// <summary>
        /// Gets or sets the inspection date.
        /// </summary>
        /// <value>The inspection date.</value>
        public DateTime? inspectionDate { get; set; }

        /// <summary>
        /// Gets or sets the state of the vehicle owner.
        /// </summary>
        /// <value>The state of the vehicle owner.</value>
        public string vehicleOwnerState { get; set; }

        /// <summary>
        /// Gets or sets the vehicle owner zip code.
        /// </summary>
        /// <value>The vehicle owner zip code.</value>
        public string vehicleOwnerZipCode { get; set; }

        /// <summary>
        /// Gets or sets the color of the exterior.
        /// </summary>
        /// <value>The color of the exterior.</value>
        public string exteriorColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the interior.
        /// </summary>
        /// <value>The color of the interior.</value>
        public string interiorColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MBEWrapperAPI.Models.ClaimInputs"/> vin decode failed.
        /// </summary>
        /// <value><c>true</c> if vin decode failed; otherwise, <c>false</c>.</value>
        public bool vinDecodeFailed { get; set; }

    }
}
